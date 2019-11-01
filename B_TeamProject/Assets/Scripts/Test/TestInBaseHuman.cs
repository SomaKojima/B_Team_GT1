using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInBaseHuman : MonoBehaviour
{
    // 総合監督の情報
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        // 木こり生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            game.HumanManager.AddHumans(CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            game.HumanManager.DeleteHumansOf(InfoOfHuman.HUMAN_TYPE.WOOD, 1);
        }
    }
}
