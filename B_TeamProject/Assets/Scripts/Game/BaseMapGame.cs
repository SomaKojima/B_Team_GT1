using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMapGame : MonoBehaviour
{
    // 総合監督の情報
    [SerializeField]
    Game game;

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
    EntityBuildingResource entityBuildingResource;

    [SerializeField]
    Transform entityBuildingResourcePosition;

    [SerializeField]
    CheckClick exchangeGate;

    [SerializeField]
    UIButtonClick cancelButton;


    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        managerOfEntityHuman.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 木こりの人数を合わせる
        InfoOfHuman.HUMAN_TYPE type = InfoOfHuman.HUMAN_TYPE.WOOD;
        JudgeCount(game.HumanManager.GetHumansOf(type).Count, managerOfEntityHuman.GetCountOf(type), type);

        // 収集
        foreach (EntityHuman human in managerOfEntityHuman.CollectHumans)
        {
            int count = entityBuildingResource.GetBuildingResourceCount();
            game.CreateLogUI(entityBuildingResource.Type.ToString() + " x" + game.BuildingManager.GetBuildingResource(entityBuildingResource.Type).Count.ToString());
            game.BuildingManager.GetBuildingResource(entityBuildingResource.Type).AddCount(count);
            human.Move.OnCollectProcess();
        }

        // 交換エリアに移動
        if (exchangeGate.IsClick)
        {
            Debug.Log("gate");
            exchangeGate.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.SELECT_EXCHANGE);
        }

        if (cancelButton.IsClick)
        {
            cancelButton.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.MAP);
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
                managerOfRoutePosition.Home,
                managerOfRoutePosition.EntityBuildingResource,
                "CollectPoint"
                ));
        }
        if (sabun < 0)
        {
            // 減らす
            managerOfEntityHuman.DeleteHumansOf(type, sabun);
        }
    }

   
}
