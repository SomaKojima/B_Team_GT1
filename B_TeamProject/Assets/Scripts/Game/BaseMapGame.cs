using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMapGame : MonoBehaviour
{
    // 総合監督の情報
    [SerializeField]
    Game game;

    [SerializeField]
    CameraType cameraType;

    [SerializeField]
    FactoryOfEntityHuman factoryOfEntityHuman;

    [SerializeField]
    ManagerOfEntityHuman managerOfEntityHuman;

    [SerializeField]
    ManagerOfRoutePosition managerOfRoutePosition;

    [SerializeField]
    FactoryOfEntityBuildingResource factoryOfEntityBuildingResource;

    [SerializeField]
    ManagerOfEntityBuildingResource managerOfEntityBuildingResource;

    [SerializeField]
    CheckClick exchangeGate;

    [SerializeField]
    UIButtonClick cancelButton;

    [SerializeField]
    GenerateFloorInstance factoryOfFloor;

    [SerializeField]
    CheckClick woodPanel;


    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        managerOfEntityHuman.Initialize();
        managerOfEntityBuildingResource.Add(factoryOfEntityBuildingResource.Create(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD));
    }

    // Update is called once per frame
    void Update()
    {
        // 木こりの人数を合わせる
        InfoOfHuman.HUMAN_TYPE type = InfoOfHuman.HUMAN_TYPE.WOOD;
        Debug.Log(cameraType.Type.ToString() + " : " + game.HumanManager.GetCountOf(game.ChangeToHumnaPlaceTypeFromCameraType(cameraType.Type)));
        if (game.HumanManager.GetCountOf(game.ChangeToHumnaPlaceTypeFromCameraType(cameraType.Type)) > managerOfEntityHuman.Humans.Count)
        {
            int infoCount = game.HumanManager.GetHumansOf(type, game.ChangeToHumnaPlaceTypeFromCameraType(cameraType.Type)).Count;
            JudgeCount(infoCount, managerOfEntityHuman.GetCountOf(type), type);
        }

        // 収集
        foreach (EntityHuman human in managerOfEntityHuman.CollectHumans)
        {
            InfoOfBuildingResource.BUILDING_RESOUCE_TYPE buildingType = ChangeFromHumanType(human.Type);
            EntityBuildingResource entity = managerOfEntityBuildingResource.EntityBRs[0];
            int count = entity.GetBuildingResourceCount();
            game.CreateLogUI(entity.Type.ToString() + " x" + game.BuildingManager.GetBuildingResource(entity.Type).Count.ToString());
            //game.BuildingManager.GetBuildingResource(entity.Type).AddCount(count);
            human.Move.OnCollectProcess();
        }

        // 人間の目的地を伝える
        foreach (EntityHuman human in managerOfEntityHuman.MoveTypeHumansOf[(int)MoveOfHuman.HUMAN_MOVE.COLLECT])
        {
            human.Move.TargetPosition = managerOfEntityBuildingResource.EntityBRs[0].CollectPos;
        }

        // 交換エリアに移動
        if (exchangeGate.IsClick)
        {
            exchangeGate.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.SELECT_EXCHANGE);
        }

        // 戻るボタン
        if (cancelButton.IsClick)
        {
            cancelButton.OnClickProcess();
            game.CamerasManager.Undo();
        }

        // 木の看板
        if (woodPanel.IsClick)
        {
            game.CreateLogUI("増築しました");
            woodPanel.OnClickProcess();
            factoryOfFloor.Create();
        }

    }

    // 人数を合わせる
    void JudgeCount(int InfoCount, int entityCount, InfoOfHuman.HUMAN_TYPE type)
    {
        int sabun = InfoCount - entityCount;
        // 増やす
        for (int i = 0; i < sabun; i++)
        {
            managerOfEntityHuman.Add(factoryOfEntityHuman.Create(
                type,
                managerOfRoutePosition.Home + new Vector3(0, 10.0f, 0),
                "CollectPoint"
                ));
        }
        if (sabun < 0)
        {
            // 減らす
            managerOfEntityHuman.DeleteHumansOf(type, sabun);
        }
    }

    InfoOfBuildingResource.BUILDING_RESOUCE_TYPE ChangeFromHumanType(InfoOfHuman.HUMAN_TYPE type)
    {
        switch (type)
        {
            case InfoOfHuman.HUMAN_TYPE.COAL_MIEAR:
                break;
            case InfoOfHuman.HUMAN_TYPE.ENGINEER:
                break;
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                return InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD;
        }

        return InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.NONE;
    }
}
