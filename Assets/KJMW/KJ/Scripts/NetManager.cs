using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class NetManager : MonoBehaviourPunCallbacks
{
    string ver = "1";

    PhotonView pv;

    public Player m_player;

    public InputField m_colorR;
    public InputField m_colorG;
    public InputField m_colorB;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        PhotonNetwork.GameVersion = ver;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected();
        print("OnConnected");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("OnJoinedLobbyzz");
        RoomOptions option = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom("JKU", option, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("CreatedRoom");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("joinedroom");

        //if (PhotonNetwork.IsMasterClient)//방장일때
        //{
          m_player = PhotonNetwork.Instantiate("Player", new Vector3(0, 0, -2), Quaternion.identity).GetComponent<Player>(); 
        //}
        //else
        //{
        //    PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
        //}
    }


    //방나가기
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        print("방나감");
    }

    public void OnChangeColor()
    {
        var valueR = float.Parse(m_colorR.text);
        var valueG = float.Parse(m_colorG.text);
        var valueB = float.Parse(m_colorB.text);
        m_player.setColor(valueR, valueG, valueB);
    }
}

