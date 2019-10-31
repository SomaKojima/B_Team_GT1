using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMapGame : MonoBehaviour
{
    // 総合監督の情報
    [SerializeField]
    Game infoGame;

    [SerializeField]
    FactoryOfEntityHuman factoryOfEntityHuman;

    [SerializeField]
    ManagerOfEntityHuman managerOfEntityHuman;

    [SerializeField]
    ManagerOfRoutePosition managerOfRoutePosition;
    


    // Start is called before the first frame update
    void Start()
    {
        managerOfEntityHuman.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 木こりの人数を合わせる
        InfoOfHuman.HUMAN_TYPE type = InfoOfHuman.HUMAN_TYPE.WOOD;
        JudgeCount(infoGame.HumanManager.GetHumansOf(type).Count, managerOfEntityHuman.GetCountOf(type), type);

        // 目的地に移動
        //foreach (EntityHuman human in managerOfEntityHuman.Humans)
        //{
        //    human.TargetPosition = ChangeToVector3FromMoveType(human.MoveType, human.transform.position);
        //}
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
                managerOfRoutePosition.EntityBuildingResource
                ));
        }
        if (sabun < 0)
        {
            // 減らす
            managerOfEntityHuman.DeleteHumansOf(type, sabun);
        }
    }
}
