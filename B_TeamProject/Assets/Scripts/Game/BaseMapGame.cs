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
    }

    void JudgeCount(int InfoCount, int entityCount, InfoOfHuman.HUMAN_TYPE type)
    {
        int sabun = InfoCount - entityCount;
        // 増やす
        for (int i = 0; i < sabun; i++)
        {
            managerOfEntityHuman.Add(factoryOfEntityHuman.Create(type, new Vector3(10.0f, 10.0f, -2.0f)));
        }
        if (sabun < 0)
        {
            // 減らす
            managerOfEntityHuman.DeleteHumansOf(type, sabun);
        }
    }
}
