using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spraytriggerBlue : MonoBehaviour
{
    public GameObject texture;
    TexturePainterBlue Tp;
    // Start is called before the first frame update
    void Start()
    {
        texture = GameObject.Find("TexturePainterBlue");
        Tp = texture.GetComponent<TexturePainterBlue>();
        ad = gameObject.GetComponent<AudioSource>();
        move = gameObject.transform.position;
    }
    AudioSource ad;
    Vector3 move;
    public int ShakeSpeed = 10;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 2)
        {
            Tp.handOn = true;
            Tp.DoAction();
            float Movespeed = Getspeed();
            if (Movespeed > ShakeSpeed)
            {
                if (ad.isPlaying) return;
                else ad.PlayOneShot(ad.clip);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {

        Tp.handOn = false;
    }
    float Getspeed()
    {
        float speed = (transform.position - move).magnitude / Time.deltaTime;
        move = transform.position;
        return speed;
    }
}
