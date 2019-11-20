using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVManager : Photon.MonoBehaviour
{

    //同期する変数1
    public int hensu1 = 0;
    public float hensu2 = 0f;

    private PlayerInfo[] playerInfos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) 
        {
            playerInfos[i].Area1Point = 0;
            playerInfos[i].Area2Point = 0;
            playerInfos[i].Area3Point = 0;
            playerInfos[i].Area4Point = 0;
            playerInfos[i].Area5Point = 0;
            playerInfos[i].Area6Point = 0;
            playerInfos[i].TradeFlag = false;
            playerInfos[i].PlayerID = i + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(hensu1);
            stream.SendNext(hensu2);

            for (int i = 0; i < 4; i++)
            {
                stream.SendNext(playerInfos[i].Area1Point);
                stream.SendNext(playerInfos[i].Area2Point);
                stream.SendNext(playerInfos[i].Area3Point);
                stream.SendNext(playerInfos[i].Area4Point);
                stream.SendNext(playerInfos[i].Area5Point);
                stream.SendNext(playerInfos[i].Area6Point);
                stream.SendNext(playerInfos[i].TradeFlag);
                stream.SendNext(playerInfos[i].PlayerID);
            }
        }
        else
        {
            //データの受信
            this.hensu1 = (int)stream.ReceiveNext();
            this.hensu2 = (int)stream.ReceiveNext();

            for (int i = 0; i < 4; i++)
            {
                this.playerInfos[i].Area1Point = (int)stream.ReceiveNext();
                this.playerInfos[i].Area2Point = (int)stream.ReceiveNext();
                this.playerInfos[i].Area3Point = (int)stream.ReceiveNext();
                this.playerInfos[i].Area4Point = (int)stream.ReceiveNext();
                this.playerInfos[i].Area5Point = (int)stream.ReceiveNext();
                this.playerInfos[i].Area6Point = (int)stream.ReceiveNext();
                this.playerInfos[i].TradeFlag = (bool)stream.ReceiveNext();
                this.playerInfos[i].PlayerID = (int)stream.ReceiveNext();
            }
        }
    }
}
