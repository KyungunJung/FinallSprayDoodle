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

    //public InputField m_colorR;
    //public InputField m_colorG;
    //public InputField m_colorB;

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

        if (PhotonNetwork.IsMasterClient)//방장일때
        {
            //PhotonNetwork.Instantiate("WhaleModel", new Vector3(0.96f, -0.23f, 4.02f), Quaternion.identity);//.GetComponent<Player>();
            PhotonNetwork.Instantiate("Can", new Vector3(0, 0, 2.93f), Quaternion.identity);

        }
        else
        {
            PhotonNetwork.Instantiate("Can", new Vector3(1, 0, 2.93f), Quaternion.identity);
        }
    }


    //방나가기
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        print("방나감");
    }


}

