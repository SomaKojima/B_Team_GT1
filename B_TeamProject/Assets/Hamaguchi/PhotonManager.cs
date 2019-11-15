using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotonManager : Photon.MonoBehaviour
{
    [SerializeField]
    private GameObject m_CreateBtnObj;
    [SerializeField]
    private GameObject m_JoinBtnObj;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby()");
        //ボタンを押せるようにする
        m_CreateBtnObj.GetComponent<Button>().interactable = true;
        m_JoinBtnObj.GetComponent<Button>().interactable = true;

    }

    public void ConnectPhoton()
    {
        //PhotonNetwork.ConnectUsingSettings(null);
    }

    //ルーム作成
    public void CreateRoom()
    {
        string userName = "ユーザ1";
        string userId = "user1";
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("userName", userName); //ユーザ名
        customProp.Add("userId", userId); //ユーザID
        PhotonNetwork.SetPlayerCustomProperties(customProp);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.customRoomProperties = customProp;
        //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.customRoomPropertiesForLobby = new string[] { "userName", "userId" };
        roomOptions.maxPlayers = 4; //部屋の最大人数
        roomOptions.isOpen = true; //入室許可する
        roomOptions.isVisible = true; //ロビーから見えるようにする
        //userIdが名前のルームがなければ作って入室、あれば普通に入室する。
        PhotonNetwork.JoinOrCreateRoom(userId, roomOptions, null);
    }

    //ルーム入室した時に呼ばれるコールバックメソッド
    void OnJoinedRoom()
    {
        Debug.Log("PhotonManager OnJoinedRoom");
        m_JoinBtnObj.GetComponent<Button>().interactable = false;
        m_CreateBtnObj.GetComponent<Button>().interactable = false;
    }

    //ルーム一覧が取れると
    void OnReceivedRoomListUpdate()
    {
        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0)
        {   
            Debug.Log("ルームが一つもありません");
        }
        else
        {
            //ルームが1件以上ある時ループでRoomInfo情報をログ出力
            for (int i = 0; i < rooms.Length; i++)
            {
                Debug.Log("RoomName:" + rooms[i].name);
                Debug.Log("userName:" + rooms[i].customProperties["userName"]);
                Debug.Log("userId:" + rooms[i].customProperties["userId"]);
                //GameObject.Find("StatusText").GetComponent<Text>().text = rooms[i].name;
            }
        }

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("user1");
    }

}
