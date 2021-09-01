using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviourPunCallbacks
{
    //Transform의 정보를 동기화 하는 역할이 PhotonView
    public PhotonView PV;
    //캐릭터의 색을 구분하기 위해 렌더러를 통해서 큐브 색을 변경할 변수
    public Renderer m_renderer;

    void Update()
    {
        //접속자가 나인 경우
        if (PV.IsMine)
        {
            float speed = 20;
            float h = Input.GetAxisRaw("Mouse X");
            float v = Input.GetAxisRaw("Mouse Y");
            transform.Translate(new Vector3(h, v, 0) * Time.deltaTime * speed);
        }
    }

    public void setColor(float colorR, float colorG, float colorB)
    {
        //컬러의 색을 동기화 하기 위해 만든 함수
        PV.RPC("receiveColor", RpcTarget.AllBuffered, colorR, colorG, colorB);
    }

    //모든 접속자가 정보를 동기화 하기 위해서는 [PunRPC] 명시
    [PunRPC]
    void receiveColor(float colorR, float colorG, float colorB)
    {
        m_renderer.material.color = new Color(colorR, colorG, colorB);
    }
}