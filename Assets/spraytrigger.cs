using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spraytrigger : MonoBehaviour
{
    public GameObject texture;
    TexturePainter Tp;
    // Start is called before the first frame update
    void Start()
    {
        Tp = texture.GetComponent<TexturePainter>();
        print("찾았냐");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Hand"))
        {
            //AudioSource audiosoure =GameObject.Find("SoundManager").GetComponent<AudioSource>();
            //audiosoure.PlayOneShot(audiosoure.clip);
            Tp.handOn = true;
            Tp.DoAction();


        }
        else
            Tp.handOn = false;


    }

}
