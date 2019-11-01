﻿using System.Collections;
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
            game.BuildingManager.GetBuildingResource(entityBuildingResource.Type).AddCount(entityBuildingResource.GetBuildingResourceCount());
            human.Move.OnCollectProcess();
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
