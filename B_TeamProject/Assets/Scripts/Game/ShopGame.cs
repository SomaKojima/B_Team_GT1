using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    ExchangeUnitManager exchangeUnitManager;

    [SerializeField]
    ExcB_Manager buttonManager;

    [SerializeField]
    ExcB_Factory buttonFactory;

    [SerializeField]
    UIButtonClick cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();

        ///-----------------------------------------------------
        /// テスト用のユニットを作成
        ///-----------------------------------------------------
        ExchangeUnit unitNecce = CreateExchangeUnit.CreateNone();
        InfoOfHuman humanNecce = new InfoOfHuman();
        humanNecce.Initialize(InfoOfHuman.HUMAN_TYPE.WOOD);
        unitNecce.AddNecessaty(humanNecce);
        exchangeUnitManager.Add(unitNecce);

        ExchangeUnit unitPre = CreateExchangeUnit.CreateNone();
        InfoOfHuman humanPre = new InfoOfHuman();
        humanPre.Initialize(InfoOfHuman.HUMAN_TYPE.WOOD);
        unitPre.AddPresentation(humanPre);
        exchangeUnitManager.Add(unitPre);


        // ユニットの作成
        exchangeUnitManager.Add(CreateExchangeUnit.Create());
        exchangeUnitManager.Add(CreateExchangeUnit.Create());

        // ユニットからボタンを作成
        foreach (ExchangeUnit unit in exchangeUnitManager.Units)
        {
            buttonManager.AddButton(buttonFactory.CreateButton(unit));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ボタンが押された
        foreach (ExchangeButton button in buttonManager.GetPressedButtons())
        {
            Exchange(button.ID);
            // ボタンの処理
            button.OnClickProcess();
        }

        if(cancelButton.IsClick)
        {
            cancelButton.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.SELECT_EXCHANGE);
        }
    }

    // 交換の処理
    void Exchange(int id)
    {
        // IDからユニットを取得
        ExchangeUnit unit = exchangeUnitManager.Get(id);

        Debug.Log("ボタンのID:" + id + "ユニットのID:" + unit.ID);
        if (unit != null)
        {
            if (game.HumanManager.CheckHumansOf(unit.NecessatyHumans))
            {
                game.HumanManager.DeleteHumansOf(unit.NecessatyHumans);
                game.HumanManager.AddHumans(unit.PresentationHumans);
                Debug.Log("交換できました");
            }
            else
            {
                foreach (InfoOfHuman human in unit.NecessatyHumans)
                {
                    Debug.Log(human.Type.ToString() + "がいません");
                }
            }
        }
    }
}
