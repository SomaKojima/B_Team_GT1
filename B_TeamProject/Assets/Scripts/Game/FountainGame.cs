using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 噴水のシーン
public class FountainGame : MonoBehaviour
{
    [SerializeField]
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

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーを選択するボタンを作成
        for(int i = 0; i < 4; i++)
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
            SelectExchange_OKButton.OnClick();
            // UIの切り替え
            uiModeManager.ChangeMode(ExcP_UIModeManager.EXCP_UI_MODE.EXCHANGE_QR_MODE);
        }

    }
}
