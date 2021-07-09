using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    public Image im;
    Color color;
    public GameObject Can;
    private void Start()
    {
        color = new Color(im.color.r, im.color.g, im.color.b, im.color.a);
        StartCoroutine(Co_ChangeAlpha());
    }

    IEnumerator Co_ChangeAlpha()
    {
        while (true)
        {
            color.a+= Time.deltaTime *- 0.5f;
            im.color = color;
            if(color.a <= 0)
            {
                Can.SetActive(true);
            }
            yield return null;
        }
    }
}