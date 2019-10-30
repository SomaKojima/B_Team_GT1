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

    }

    // Update is called once per frame
    void Update()
    {
        // 木こり生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            managerOfEntityHuman.Add(factoryOfEntityHuman.Create(InfoOfHuman.HUMAN_TYPE.WOOD, new Vector3( 10.0f, 10.0f, -2.0f)));
        }
    }

    //void EntityHumanManager.JudgeCount(int count)
    //{
    //    int sabun = count - list.length;
    //    // 増やす
    //    for (int i = 0; i < sabun; i++)
    //    {
    //        list.AddHumans(CreateEntityHuman.Create());
    //    }
    //    // 減らす
    //    for (int i = 0; i > sabun; i--)
    //    {
    //        list.delete();
    //    }
    //}
}
