using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    [SerializeField]
    Game game;

    [SerializeField]
    ExchangeUnitManager exchangeUnitManager;

    [SerializeField]
    ExcB_Manager buttonManager;

    [SerializeField]
    ExcB_Factory buttonFactory;

    // Start is called before the first frame update
    void Start()
    {
        // ユニットの作成
        exchangeUnitManager.Add(CreateExchangeUnit.Create());

        // ユニットからボタンを作成
        foreach (ExchangeUnit unit in exchangeUnitManager.Units)
        {
            buttonManager.AddButton(buttonFactory.CreateButton(
                unit.PresentationHuman.Type.ToString(),
                unit.NecessatyHuman.Type.ToString(),
                unit.ID));
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
    }

    // 交換の処理
    void Exchange(int id)
    {
        // IDからユニットを取得
        ExchangeUnit unit = exchangeUnitManager.Get(id);

        Debug.Log("ボタンのID:" + id + "ユニットのID:" + unit.ID);
        if (unit != null)
        {
            if (game.HumanManager.CheckHumansOf(unit.NecessatyHuman.Type))
            {
                game.HumanManager.DeleteHumansOf(unit.NecessatyHuman.Type, 1);
                game.HumanManager.AddHumans(unit.PresentationHuman);
                Debug.Log("交換できました");
            }
            else
            {
                Debug.Log(unit.NecessatyHuman.Type.ToString() + "がいません");
            }
        }
    }
}
