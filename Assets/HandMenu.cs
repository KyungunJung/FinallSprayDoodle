using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    public GameObject whale;
    public GameObject wall;
   
 
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void OnClickOne()
    {
        if(whale.activeSelf == true)
        {
            whale.SetActive(false);
        }
        else
        {
            whale.SetActive(true);
        }


    }


    public void OnClickTwo()
    {
        if (wall.activeSelf == true)
        {
            wall.SetActive(false);
        }
        else
        {
            wall.SetActive(true);
        }
    }
}


