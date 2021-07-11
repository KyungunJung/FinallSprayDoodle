using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject frontH;
    public GameObject backH;

    FrontHand fhsc;
    BackHand bhsc;

    void Start()
    {
        fhsc = frontH.GetComponent<FrontHand>();
        bhsc = backH.GetComponent<BackHand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FaintShot()
    {

    }

}
