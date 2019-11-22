using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessListManager : MonoBehaviour
{
    // 表示状態切り替え
    private bool menuState = false;

    // 所持リストの幅
    [SerializeField]
    private float ListUIWidth;

    // カメラ内に表示されているか
    private bool isVisible = false;

    // 所持リストオブジェクト
    private GameObject listUI = null;

    // 所持リストを生成するスクリプト
    [SerializeField]
    FactoryProcessList factoryProcessList;
    // エリア内にオブジェクトが存在しているか調べるスクリプト
    [SerializeField]
    CheckCountainArea checkCountainArea;
    // 所持リストの表示/非表示を管理するスクリプト
    [SerializeField]
    MoveProcessList moveProcessList;

    //CameraManager cameraManager = null;


    // Start is called before the first frame update
    void Start()
    {
        //cameraManager = GetComponent<CameraManager>();
        // 所持リストUI生成
        //listUI = factoryProcessList.Create();

        //// 基点設定
        //Vector3 listUIBasePoint = new Vector3(listUI.transform.localPosition.x/* + (ListUIWidth * 0.5f)*/,
        //                                      listUI.transform.localPosition.y,
        //                                      listUI.transform.localPosition.z);
        //moveProcessList.ListBasePos = listUIBasePoint;
    }

    // Update is called once per frame
    void Update()
    {
        ControllProcessList();
    }

    // 所持リストの操作
    public void ControllProcessList(/*cameraTypeInfo*/)
    {
        //if (cameraTypeInfo < CameraType.CAMERA_TYPE.WOOD && cameraTypeInfo >= CameraType.CAMERA_TYPE.SHOP) return;

        // 表示状態切り替え
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (listUI == null)
            {
               // 所持リストUI生成
               listUI = factoryProcessList.Create();

               // 基点設定
               Vector3 listUIBasePoint = new Vector3(listUI.transform.localPosition.x + (ListUIWidth * 0.5f),
                                                     listUI.transform.localPosition.y,
                                                     listUI.transform.localPosition.z);
                moveProcessList.ListBasePos = listUIBasePoint;

               // メッセージ設定
               //Text listUIText = listUI.transform.FindChild("HumanList/Humans").GetComponent<Text>();
               // listUIText.text = "test";
            }

            // UI移動
            moveProcessList.MoveState = true;
            // フラグを反転
            menuState = !menuState;
        }

        // カメラ内に表示されているか
        isVisible = checkCountainArea.IsCountainCanvasArea(moveProcessList.ListBasePos, 0.0f, 0.0f);
        // 所持リストの表示/非表示
        moveProcessList.MoveList(isVisible, menuState, ref listUI, ListUIWidth);

        {
            /*listUI.transform.localPosition = Vector3.Lerp(new Vector3(350.0f,
                                                                      listUI.transform.localPosition.y,
                                                                      listUI.transform.localPosition.z), 
                                                            new Vector3(720.0f,
                                                                      listUI.transform.localPosition.y,
                                                                      listUI.transform.localPosition.z), 
                                                            Time.deltaTime * 2);*/
        }
    }

    // 取得関数
    public bool IsVisible() { return isVisible; }
}
