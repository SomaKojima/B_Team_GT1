using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 噴水のシーン
public class FountainGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    ExcB_FactorySelectPlayer factorySelectPlayer;

    [SerializeField]
    ExcB_ManagerOfSelectPlayer managerOfSelectPlayer;

    [SerializeField]
    ExcP_UIModeManager uiModeManager;

    [SerializeField]
    ExcB_FactorySelectExchange factorySelectExchange;

    [SerializeField]
    ExcB_ManagerOfSelectExchange managerOfSelectExchange;

    [SerializeField]
    OKButton SelectExchange_OKButton;

    [SerializeField]
    QRcodeManager qrCodeManager;

    [SerializeField]
    UIButtonClick cancelButton;

    // QRコードを生成する文字列
    [SerializeField]
    string testStr;



    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();

        // プレイヤーを選択するボタンを作成
        for (int i = 0; i < 4; i++)
        {
            managerOfSelectPlayer.Add(factorySelectPlayer.Create("", i));
        }

        // 資源を選択するボタンを作成
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            InfoOfHuman.HUMAN_TYPE type = (InfoOfHuman.HUMAN_TYPE)i;
            managerOfSelectExchange.Add(factorySelectExchange.Create(type.ToString(), i));
        }

        // UIのモードを初期化
        uiModeManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ExcB_SelectExchange button in managerOfSelectExchange.Buttons)
        {
            button.CurrentCount = 100;
        }

        ///-------------------------------------------------------------------------------------------------------
        ///プレイヤーを選択中の処理
        ///-------------------------------------------------------------------------------------------------------
        // ボタンが押された
        foreach (ExcB_SelectPlayer button in managerOfSelectPlayer.GetClickButtons())
        {
            // ボタンの処理
            button.OnClickProcess();

            // UIの切り替え
            uiModeManager.ChangeMode(ExcP_UIModeManager.EXCP_UI_MODE.SELECT_EXCHANGE);
        }

        ///-------------------------------------------------------------------------------------------------------
        ///資源を選択中の処理
        ///-------------------------------------------------------------------------------------------------------
        if (SelectExchange_OKButton.IsClick)
        {
            SelectExchange_OKButton.OnClickProcess();

            ActiveQR();

            // UIの切り替え
            uiModeManager.ChangeMode(ExcP_UIModeManager.EXCP_UI_MODE.EXCHANGE_QR_MODE);

            game.PvManager.PLInfoTreadFlagSet(game.PvManager.MyIDGet(), true);
        }

        if(uiModeManager.END != ExcP_UIModeManager.EXCP_UI_MODE.EXCHANGE_QR_MODE &&
            uiModeManager.IsChange)
        {
            // QRコード非表示
            qrCodeManager.SetActiveQRcode(false);
            game.PvManager.PLInfoTreadFlagSet(game.PvManager.MyIDGet(), false);
        }


        ///-------------------------------------------------------------------------------------------------------
        ///戻るボタンの処理
        ///-------------------------------------------------------------------------------------------------------
        if (cancelButton.IsClick)
        {
            if (uiModeManager.Mode == ExcP_UIModeManager.EXCP_UI_MODE.SELECT_PLAYER)
            {
                game.CamerasManager.Undo();
            }
            cancelButton.OnClickProcess();
            uiModeManager.BackMode();
        }

        void ActiveQR()
        {
            // QRコード表示
            qrCodeManager.SetActiveQRcode(true);

            // 表示するモノの切り替えのためのフラグ反転
            if (Input.GetKeyDown(KeyCode.Space))
            {
                qrCodeManager.SetIsRead();
            }

            // true＝カメラに映っているものを表示
            if (qrCodeManager.IsRead)
            {
                if (!qrCodeManager.IsPlayCamera)
                {
                    // カメラの起動
                    qrCodeManager.ActivationWebCamera();
                    // カメラ起動フラグを立てる
                    qrCodeManager.IsPlayCamera = true;
                }
                if (qrCodeManager.IsPlayCamera)
                {
                    // カメラが起動していたら画像をそのまま張り付ける
                    qrCodeManager.QRImage = qrCodeManager.WebCam;
                }
            }
            // false＝文字からQRコードを表示
            else
            {
                // 起動中だったら
                if (qrCodeManager.IsPlayCamera)
                {
                    // カメラを停止させる
                    qrCodeManager.DeactivationWebCamera();
                    // カメラ起動フラグを伏せる
                    qrCodeManager.IsPlayCamera = false;
                }

                // 文字列からQRコードを生成、Imageに張り付ける
                qrCodeManager.QRImage = qrCodeManager.CreateQRcode(testStr);
                Debug.Log(testStr);
            }
        }
    }
}
