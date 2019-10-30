using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInBaseHuman : MonoBehaviour
{
    // 総合監督の情報
    [SerializeField]
    Game infoGame;



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
            infoGame.HumanManager.AddHumans(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            infoGame.HumanManager.DeleteHumansOf(InfoOfHuman.HUMAN_TYPE.WOOD, 1);
        }
    }
}
