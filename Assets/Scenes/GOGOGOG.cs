using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOGOGOG : MonoBehaviour
{
    public GameObject prefabCube;

    public GameObject[] cubes;
    int indexCube = 0;
    int removeCube = 0;


    // Update is called once per frame
    void Update()
    {
        InstantiateCube();
        RemoveCube();
    }
    void InstantiateCube()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
          cubes[indexCube]  = Instantiate(prefabCube);
          indexCube++;
          if(indexCube == cubes.Length)
            {
                indexCube = 0;
            }
        }
    }

    void RemoveCube()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Destroy(cubes[removeCube]);
            cubes[removeCube] = null;
            removeCube++;
            if (removeCube == cubes.Length)
            {
                removeCube = 0;
            }
        }
    }
}
