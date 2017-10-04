using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLetter : MonoBehaviour {

    public GameObject letter;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name + " collision detected");
        if (col.gameObject == letter.gameObject)
        {
            Debug.Log(letter.gameObject.name + " Well placed");
        }
    }
}
