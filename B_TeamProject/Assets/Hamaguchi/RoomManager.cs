using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player1;
    [SerializeField]
    private GameObject m_Player2;
    [SerializeField]
    private GameObject m_Player3;
    [SerializeField]
    private GameObject m_Player4;
    [SerializeField]
    private GameObject m_StartBtnObj;

    public bool StartFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMemberList();
    }

    // Update is called once per frame
    void Update()
    {
        if(StartFlag==true)
        {
            SceneManager.LoadScene("GameStartScene");
        }
    }

    //誰かがルームに入室したときに呼ばれるコールバックメソッド
    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        Debug.Log(newPlayer.name + "　が入室しました");
        UpdateMemberList();
    }

    //誰かがルームを退室したときに呼ばれるコールバックメソッド
    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log(otherPlayer.name + "　が退室しました");
        UpdateMemberList();
    }

    void UpdateMemberList()
    {
        PhotonPlayer[] players = PhotonNetwork.playerList;

        m_Player1.GetComponentInChildren<Text>().text = "None...";
        m_Player2.GetComponentInChildren<Text>().text = "None...";
        m_Player3.GetComponentInChildren<Text>().text = "None...";
        m_Player4.GetComponentInChildren<Text>().text = "None...";

        if (players.Length == 0)
        {
            Debug.Log("プレイヤーがいません");
        }
        else
        {
            for (int i = 0; i < players.Length; i++)
            {   
                switch (players[i].ID)
                {
                    case 1:
                        m_Player1.GetComponentInChildren<Text>().text = "Player1\n" + players[i].name;
                        break;
                    case 2:
                        m_Player2.GetComponentInChildren<Text>().text = "Player2\n" + players[i].name;
                        break;
                    case 3:
                        m_Player3.GetComponentInChildren<Text>().text = "Player3\n" + players[i].name;
                        break;
                    case 4:
                        m_Player4.GetComponentInChildren<Text>().text = "Player4\n" + players[i].name;
                        break;
                }
            }
        }


        if(PhotonNetwork.isMasterClient)
        {
            if (players.Length == 4)
            {
                m_StartBtnObj.GetComponent<Button>().interactable = true;
            }
            else
            {
                m_StartBtnObj.GetComponent<Button>().interactable = false;
            }

            m_StartBtnObj.GetComponent<Button>().interactable = true;
        }
        
    }

    public void GameStart()
    {
        StartFlag = true;
        
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            //stream.SendNext(hensu1);
            
        }
        else
        {
            //データの受信
            //this.hensu1 = (int)stream.ReceiveNext();
            
            
        }
    }
}
