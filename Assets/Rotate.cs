using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.transform.Rotate(new Vector3(0,0,90));
        Debug.Log("A");
    }
}
