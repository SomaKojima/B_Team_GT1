using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInBaseHuman : MonoBehaviour
{
    // 総合監督の情報
    [SerializeField]
    Game infoGame;

    // 人間管理オブジェクト
    [SerializeField]
    InfoManagerOfHumanObject humanObjectManager;

    // 人間生成位置
    [SerializeField]
    private GameObject enterPosObj = null;

    // 人間生成数
    [SerializeField]
    public int humanNum = 5;


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
            // 実体を持たない人間の数を取得
            //int humanCnt = infoGame.HumanManager.GetHumans().Length;
            // 人間の数より生成されたオブジェクトの数が少なかったら
            //if(humanCnt > humanObjectManager.GetHumanObjects().Length)
            //{
            //}
            // 位置設定
            Vector3 pos = enterPosObj.transform.position + new Vector3(0.0f, 0.0f, -1.0f);

            // テスト用(木こりに固定)
            InfoOfHuman.HUMAN_TYPE testType = InfoOfHuman.HUMAN_TYPE.WOOD;
            // 人種に応じて実体取得
            GameObject obj = humanObjectManager.OrderInHumanType(testType);

            // リストにオブジェクトを追加
            humanObjectManager.AddHumanObjects(CreateInfoOfHumanObject.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD, obj, pos, InfoOfHumanObject.HUMAN_MOVE.MOVE));
            // スケール調整
            humanObjectManager.GetHumanObjects()[humanObjectManager.GetHumanObjects().Length - 1].Scale = new Vector3(0.6f, 0.6f, 1.0f);

            // オブジェクト生成(初期設定：位置と回転)
            Instantiate(humanObjectManager.GetHumanObjects()[humanObjectManager.GetHumanObjects().Length - 1].Object,
                        humanObjectManager.GetHumanObjects()[humanObjectManager.GetHumanObjects().Length - 1].Pos, Quaternion.identity);

            // 移動ステート設定
            //humanHowToMoveStateList.Add(moveState);
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
