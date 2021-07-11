using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class TextureShare : MonoBehaviourPunCallbacks
{
    public static TextureShare instance;

    public PhotonView pv;
    public Material baseMaterial;
    public Material baseMaterial2;
    Texture2D tex;
    public RenderTexture canvasTexture;
    public RenderTexture canvasTexture2;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void TextureSharing(byte[] _Texture)
    {
        print("TextureSharing");
        pv.RPC("RPC_TextureSharing", RpcTarget.All, _Texture);
    }
    public void TextureSharing2(byte[] _Texture)
    {
        print("TextureSharing");
        pv.RPC("RPC_TextureSharing2", RpcTarget.All, _Texture);
    }

    void MaterialChange(byte[] _Texture)
    {
        print("MaterialChange");
        RenderTexture.active = canvasTexture;
        Texture2D tex = new Texture2D(canvasTexture.width, canvasTexture.height, TextureFormat.ARGB32, false);
        tex.LoadImage(_Texture);
        tex.Apply();
        RenderTexture.active = null;
        baseMaterial.mainTexture = tex;
    }
    void MaterialChange2(byte[] _Texture)
    {
        print("MaterialChange2");
        RenderTexture.active = canvasTexture2;
        Texture2D tex = new Texture2D(canvasTexture2.width, canvasTexture2.height, TextureFormat.ARGB32, false);
        tex.LoadImage(_Texture);
        tex.Apply();
        RenderTexture.active = null;
        baseMaterial2.mainTexture = tex;
    }
    [PunRPC]
    public void RPC_TextureSharing(byte[] _Texture)
    {
        MaterialChange(_Texture);
    
    }
    [PunRPC]
    public void RPC_TextureSharing2(byte[] _Texture)
    {
 
        MaterialChange2(_Texture);
    }

}