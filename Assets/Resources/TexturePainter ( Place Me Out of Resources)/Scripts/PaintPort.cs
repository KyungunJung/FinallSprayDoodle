using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPort : MonoBehaviour
{
    public Color bolletC;
    public GameObject[] sprayObj;
    GameObject tempObj;
    Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ButtonRed")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = true;

            sprayObj[0].transform.parent = gameObject.transform;
            sprayObj[0].transform.position = Vector3.zero;
            tempObj = sprayObj[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //tempObj.transform.parent = null;
        //rb.isKinematic = false;
    }
}
