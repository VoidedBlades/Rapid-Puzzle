using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Randomizer : MonoBehaviour
{   
    [SerializeField] private string[] TextureName;
    [SerializeField] private Sprite[] Sprites;

    [SerializeField] private GameObject[] InstanicatedSprites;

    [SerializeField] private Vector2 StartPos;
    [SerializeField] private GameObject SpritePrefab;
    [SerializeField] private float offsetX,offsetY;

    private Rect start;
    private float CurrentX, CurrentY;

    /// <summary>
    /// Aligns and rotates all the objects
    /// </summary>
    private void Align()
    {
        int current = 0;
        foreach (Sprite sp in Sprites)
        {

            if (sp.rect.x == start.x)
            {
                CurrentY += offsetY;
                CurrentX = 0f;
            }

            int random = Random.Range(0,4);

            GameObject x = Instantiate(SpritePrefab);
            x.GetComponent<SpriteRenderer>().sprite = sp;
            x.transform.position = StartPos+new Vector2(CurrentX, -CurrentY);
            x.transform.rotation = new Quaternion(0,0,90*random, 0);

            InstanicatedSprites[current] = x;

            CurrentX += offsetX;
            current += 1;
        }
    }

    /// <summary>
    /// start, initialization of the game
    /// </summary>
    void Start()
    {
        CurrentX = 0;
        CurrentY = 0;

        int random = Random.Range(0, TextureName.Length);
        Sprites = Resources.LoadAll<Sprite>(TextureName[random]);
        start = Sprites[0].rect;

        InstanicatedSprites = new GameObject[Sprites.Length];

        Align();
    }

    /// <summary>
    /// checks if all the objects are rotated at their original rotation
    /// </summary>
    void Update()
    {
        int correct = 0;
        foreach(GameObject sprite in InstanicatedSprites)
        {
            if (sprite.transform.rotation.z == 0)
                correct += 1;
        }

        if (correct == Sprites.Length)
            Debug.Log("Win");
    }
}
