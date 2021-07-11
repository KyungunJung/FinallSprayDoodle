using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHand : MonoBehaviour
{
    public bool OnbackHand = false;

 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 2)
        {
            OnbackHand = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnbackHand = false;
    }
}
