using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveProcessList : MonoBehaviour
{
    // 表示状態切り替え
    private bool menuState = false;
    // 動作状態切り替え
    private bool moveState = false;

    // 動かすスピード
    [SerializeField]
    private float moveSpeed = 20.0f;

    //UGUIを表示してるカメラを貼り付ける
    [SerializeField]
    private Camera camera = null;


    // Rect
    private Rect rect = new Rect(0, 0, 1, 1);
    // カメラ内に表示されているか
    private bool isVisible = false;

    // リストを表示しているキャンバス
    [SerializeField]
    private GameObject canvas = null;
    // 所持リストのプレハブ
    [SerializeField]
    private GameObject listPrefab = null;
    // 所持リストオブジェクト
    private GameObject listUI;
    // 表示/非表示用のリストの基点
    private Vector3 listUIBasePoint = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {        
        // 所持リストUI生成
        listUI = Instantiate(listPrefab) as GameObject;
        listUI.transform.SetParent(canvas.transform, false);
        listUI.transform.localPosition = new Vector3(700.0f, 420.0f, 0.0f);

        // UIの幅(0～1の値)
        float uiWidth = listUI.GetComponent<RectTransform>().rect.width / listUI.GetComponent<RectTransform>().rect.width
                        * 0.3f;

        // 基点設定
        listUIBasePoint = new Vector3(listUI.transform.position.x + (uiWidth * 0.5f),
                                      listUI.transform.position.y,
                                      listUI.transform.position.z);

        // メッセージ設定
        //Text listUIText = listUI.transform.FindChild("HumanList/Humans").GetComponent<Text>();
        //listUIText.text = "test";
    }

    // Update is called once per frame
    void Update()
    {
        // UIの幅(0～1の値)
        float uiWidth = listUI.GetComponent<RectTransform>().rect.width / listUI.GetComponent<RectTransform>().rect.width
                        * 0.3f;

        // 表示状態切り替え
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // UI移動
            moveState = true;
            // フラグを反転
            menuState = !menuState;
        }

        // カメラ内に表示されているか
        isVisible = rect.Contains(camera.WorldToViewportPoint(listUIBasePoint));

        if (!isVisible && menuState)
        {
            if (!moveState) return;
            listUI.transform.localPosition -= new Vector3(moveSpeed, 0, 0);
            listUIBasePoint = transform.TransformPoint(listUI.transform.localPosition);
            listUIBasePoint.x += (uiWidth * 0.35f);
        }
        else if(isVisible && !menuState)
        {
            if (!moveState) return;
            listUI.transform.localPosition += new Vector3(moveSpeed, 0, 0);
            listUIBasePoint = transform.TransformPoint(listUI.transform.localPosition);
            listUIBasePoint.x -= (uiWidth * 0.35f);
        }
        else
        {
            moveState = false;
        }

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
