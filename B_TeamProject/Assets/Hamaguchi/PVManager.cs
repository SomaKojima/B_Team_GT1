using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVManager : Photon.MonoBehaviour
{

    //同期する変数1
    public int hensu1 = 0;
    public float hensu2 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            //データの受信
            this.hensu1 = (int)stream.ReceiveNext();
            this.hensu2 = (int)stream.ReceiveNext();
        }
    }
}
