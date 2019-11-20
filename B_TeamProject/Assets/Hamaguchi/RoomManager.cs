using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        UpdateMemberList();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
