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

        humanNecce = new InfoOfHuman();
        humanNecce.Initialize(InfoOfHuman.HUMAN_TYPE.WOOD);


        unitNecce.AddPresentation(humanNecce);


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
            game.CamerasManager.Undo();
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

                // 交換時の初期化
                foreach (InfoOfHuman human in unit.PresentationHumans)
                {
                    human.PlaceType = game.GetHumanPlaceType();
                }
                game.HumanManager.AddHumans(unit.PresentationHumans);
                CreateLogUIOfExchange(unit.NecessatyHumans, unit.PresentationHumans);
            }
            else
            {
                game.CreateLogUI("交換に必要な人数が足りません");
            }
        }
    }

    void CreateLogUIOfExchange(List<InfoOfHuman> delete, List<InfoOfHuman> get)
    {
        string buf = "";
        for (int i = 0; i < delete.Count; i++)
        {
            buf += delete[i].Type.ToString();
            if (i != delete.Count - 1)
            {
                buf += "と";
            }
        }
        buf += "を\n";

        for (int i = 0; i < get.Count; i++)
        {
            buf += get[i].Type.ToString();
            if (i != get.Count - 1)
            {
                buf += "と";
            }
        }
        game.CreateLogUI(buf + "に交換した");
    }

    void CreateLogUIOfGetHumans(List<InfoOfHuman> list)
    {
        foreach (InfoOfHuman human in list)
        {
            game.CreateLogUI(human.Type.ToString() + "を手に入れた");
        }
    }

    void CreateLogUIOfDeleteHumans(List<InfoOfHuman> list)
    {
        foreach (InfoOfHuman human in list)
        {
            game.CreateLogUI(human.Type.ToString() + "を失った");
        }
    }

    void CreateLogUIOfMissing(List<InfoOfHuman> list)
    {
        string buf = "";
        foreach (InfoOfHuman human in list)
        {
            buf += human.Type.ToString() + "\n";
        }
        game.CreateLogUI(buf  + "がいません");
    }
}
