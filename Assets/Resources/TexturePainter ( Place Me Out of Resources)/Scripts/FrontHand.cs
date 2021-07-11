using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontHand : MonoBehaviour
{
    public bool OnfrontHand = false;



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 2)
        {
            OnfrontHand = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnfrontHand = false;
    }
}
