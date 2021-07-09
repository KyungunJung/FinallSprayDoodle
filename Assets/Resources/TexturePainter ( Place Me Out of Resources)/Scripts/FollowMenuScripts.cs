using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMenuScripts : MonoBehaviour
{
    public GameObject[] sprays;
    public GameObject[] spraysPos;

    public void ResetSprayPos()
    {
        print("클릭");
        for(int i = 0; i < sprays.Length; i++)
        {
            sprays[i].transform.position = spraysPos[i].transform.position;
            sprays[i].transform.rotation = Quaternion.identity;
        }
    }

    public GameObject[] bgms;
    int bgmIndex = 0;

    public void ChangeBGM()
    {
        print("변경");
        if(bgmIndex == 0)
        {
            bgms[0].SetActive(true);
            bgms[bgms.Length-1].SetActive(false);

            bgmIndex++;
        }
        else
        {
            for(int i = 1; i < bgms.Length; i++)
            {
                if(i == bgmIndex)
                {
                    bgms[bgmIndex].SetActive(true);
                }
                else
                {
                    bgms[0].SetActive(false);
                    bgms[i].SetActive(false);
                }
            }
            bgmIndex++;
            if(bgmIndex == bgms.Length)
            {
                bgmIndex = 0;
            }
        }   
    }

    public GameObject brushContainer;

    public void ClearBoard()
    {
       for(int i= 0; i < bgms.Length; i++)
        {
            bgms[i].SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
