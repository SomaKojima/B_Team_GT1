using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    ExchangeUnitManager exchangeUnitManager;

    [SerializeField]
    UIButtonClick cancelButton;

    [SerializeField]
    GameObject saiteiButtons;

    [SerializeField]
    FactoryOfCommonExchangeButton factoryButton;

    [SerializeField]
    ManagerOfCommonExchangeButton managerButton;
    
    [SerializeField]
    SelectNecessaryWindow selectNecessaryWindow;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();

        CreateButton();

        // 三すくみ交換ボタン
        //CreateWoodToCoalMinerButton();
        //CreateCoalMinerToEngineerButton();
        //CreateEngineerToWoodButton();

        // ユニットからボタンを作成
        List<InfoOfHuman> humans = new List<InfoOfHuman>();
        List<InfoOfBuildingResource> brs = new List<InfoOfBuildingResource>();


        // 最低を有効にする
        saiteiButtons.SetActive(true);

        // 交換のボタンを作成
        foreach (ExchangeUnit unit in exchangeUnitManager.Units)
        {
            if (unit.NecessaryCount >= 0)
            {
                managerButton.Add(factoryButton.Create(unit.ID, unit.NecessaryCount, unit.PresentationHumans, unit.PresentationBRs));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 戻るボタン
        if(cancelButton.IsClick)
        {
            cancelButton.OnClickProcess();
            game.CamerasManager.Undo();
        }

        // 最低のボタンが押された
        foreach (CommonExchangeButton button in managerButton.GetClicks())
        {
            button.OnClickProcess();
            selectNecessaryWindow.Initialize(button.Necessary, button.ID);
            selectNecessaryWindow.gameObject.SetActive(true);
        }

        // 最低の交換をする
        if (selectNecessaryWindow.IsExchange)
        {
            selectNecessaryWindow.OnExchangeClickProcess();
            ExchangeSaitei();
        }

        // 最低の素材選択の更新
        foreach(CommonSelectIcon icon in selectNecessaryWindow.MgrCommonSelectIcon.SelectIcons)
        {
            if (icon.BRType != InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.NONE)
            {
                icon.CurrentCount = game.BuildingManager.GetBuildingResource(icon.BRType).Count;
            }
            if (icon.HumanType != InfoOfHuman.HUMAN_TYPE.NONE)
            {
                icon.CurrentCount = game.HumanManager.GetCountOf(icon.HumanType);
            }
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
            game.HumanManager.DeleteHumansOf(unit.NecessatyHumans);

            // 交換時の初期化
            foreach (InfoOfHuman human in unit.PresentationHumans)
            {
                human.PlaceType = game.GetHumanPlaceType();
            }
            game.HumanManager.AddHumans(unit.PresentationHumans);
            CreateLogUIOfExchange(unit.NecessatyHumans, unit.PresentationHumans);
        }
    }

    void ExchangeSaitei()
    {
        // IDからユニットを取得
        ExchangeUnit unit = exchangeUnitManager.Get(selectNecessaryWindow.ID);

        // 人間を減らす
        int[] count = selectNecessaryWindow.GetHumanCount();
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            game.HumanManager.DeleteHumansOf((InfoOfHuman.HUMAN_TYPE)i, count[i]);
        }

        // 資源を減らす
        count = selectNecessaryWindow.GetBRCount();
        for (int i = 0; i < (int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX; i++)
        {
            game.BuildingManager.GetBuildingResource((InfoOfBuildingResource.BUILDING_RESOUCE_TYPE)i).SubCount(count[i]);
        }

        // 人間の設置する場所を設定する
        foreach (InfoOfHuman hu in unit.PresentationHumans)
        {
            hu.PlaceType = game.GetHumanPlaceType();
        }
        // 資源・人間を取得する
        for (int i = 0; i < selectNecessaryWindow.ExcCount(); i++)
        {
            game.HumanManager.AddHumans(unit.PresentationHumans);
            game.BuildingManager.AddBRs(unit.PresentationBRs);
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
 

    void CreateButton()
    {
        ///-----------------------------------------------------
        /// 
        ///-----------------------------------------------------
        List<InfoOfHuman> humans = new List<InfoOfHuman>();
        List<InfoOfHuman> neceHuman = new List<InfoOfHuman>();
        humans.Add(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD, InfoOfHuman.PLACE_TYPE.NONE));
        ExchangeUnit unit = CreateExchangeUnit.Create(humans, null, 0);
        exchangeUnitManager.Add(unit);


        humans = new List<InfoOfHuman>();
        neceHuman = new List<InfoOfHuman>();
        humans.Add(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD, InfoOfHuman.PLACE_TYPE.NONE));
        unit = CreateExchangeUnit.Create(null, null, 1);
        exchangeUnitManager.Add(unit);

        humans = new List<InfoOfHuman>();
        neceHuman = new List<InfoOfHuman>();
        humans.Add(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.ENGINEER, InfoOfHuman.PLACE_TYPE.NONE));
        unit = CreateExchangeUnit.Create(humans, null, 1);
        exchangeUnitManager.Add(unit);

        humans = new List<InfoOfHuman>();
        neceHuman = new List<InfoOfHuman>();
        humans.Add(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.COAL_MIEAR, InfoOfHuman.PLACE_TYPE.NONE));
        unit = CreateExchangeUnit.Create(humans, null, 1);
        exchangeUnitManager.Add(unit);
    }

    ///// <summary>
    ///// 木こりをコストに炭鉱夫を取得できるボタンを生成
    ///// </summary>
    //void CreateWoodToCoalMinerButton()
    //{
    //    ExchangeUnit unit = CreateExchangeUnit.CreateNone();

    //    InfoOfHuman human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.WOOD);
    //    unit.AddNecessaty(human);

    //    human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.COAL_MIEAR);
    //    unit.AddPresentation(human);

    //    exchangeUnitManager.Add(unit);
    //}

    ///// <summary>
    ///// 炭鉱夫をコストにエンジニアを取得できるボタンを生成
    ///// </summary>
    //void CreateCoalMinerToEngineerButton()
    //{
    //    ExchangeUnit unit = CreateExchangeUnit.CreateNone();

    //    InfoOfHuman human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.COAL_MIEAR);
    //    unit.AddNecessaty(human);

    //    human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.ENGINEER);
    //    unit.AddPresentation(human);

    //    exchangeUnitManager.Add(unit);
    //}

    ///// <summary>
    ///// エンジニアをコストに木こりを取得できるボタンを生成
    ///// </summary>
    //void CreateEngineerToWoodButton()
    //{
    //    ExchangeUnit unit = CreateExchangeUnit.CreateNone();

    //    InfoOfHuman human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.ENGINEER);
    //    unit.AddNecessaty(human);

    //    human = new InfoOfHuman();
    //    human.Initialize(InfoOfHuman.HUMAN_TYPE.WOOD);
    //    unit.AddPresentation(human);

    //    exchangeUnitManager.Add(unit);
    //}
}
