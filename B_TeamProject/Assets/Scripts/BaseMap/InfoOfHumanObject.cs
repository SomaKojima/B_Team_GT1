using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOfHumanObject
{
    /// <summary>
    /// 行動一覧
    /// </summary>
    public enum HUMAN_MOVE
    {
        STOP,
        MOVE,
        TURN_X,
        TURN_Z,
        COLLECT,

        MOVE_NUM
    }

    // 人種
    InfoOfHuman.HUMAN_TYPE      type = InfoOfHuman.HUMAN_TYPE.NONE;

    // オブジェクト情報
    GameObject                  humanObject = null;

    // 人間の行動ジャンル
    HUMAN_MOVE                  moveType = HUMAN_MOVE.MOVE;


    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="_type">人種</param>
    /// <param name="_instance">生成する実体</param>
    /// <param name="_pos">位置</param>
    /// <param name="_moveType">行動ジャンル</param>
    public void Initialize(InfoOfHuman.HUMAN_TYPE _type, GameObject _instance, Vector3 _pos, HUMAN_MOVE _moveType)
    {
        type = _type;
        humanObject = _instance;
        humanObject.transform.position = _pos;
        moveType = _moveType;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="_moveType">行動ジャンル</param>
    public void Update(HUMAN_MOVE _moveType)
    {

    }


    // 人種・行動をランダムで決める
    public void RandomSet()
    {
        float randomT = Random.Range(0.0f, (float)InfoOfHuman.HUMAN_TYPE.MAX - 0.01f);
        InfoOfHuman.HUMAN_TYPE randomType = (InfoOfHuman.HUMAN_TYPE)randomT;
        float randomM = Random.Range(0.0f, (float)HUMAN_MOVE.MOVE_NUM - 0.01f);
        HUMAN_MOVE randomMoveType = (HUMAN_MOVE)randomM;

        this.type = randomType;
        this.moveType = randomMoveType;
    }

    /// <summary>
    /// 人種を取得
    /// </summary>
    public InfoOfHuman.HUMAN_TYPE Type
    {
        get { return type; }
    }

    /// <summary>
    /// 行動ジャンルを取得
    /// </summary>
    public HUMAN_MOVE MoveType
    {
        get { return moveType; }
    }

    /// <summary>
    /// 位置を取得
    /// </summary>
    public Vector3 Pos
    {
        get { return humanObject.transform.position; }
    }

    /// <summary>
    /// 大きさを取得、設定
    /// </summary>
    public Vector3 Scale
    {
        get { return humanObject.transform.localScale; }
        set { humanObject.transform.localScale = value; }
    }

    /// <summary>
    /// インスタンスを取得
    /// </summary>
    public GameObject Object
    {
        get { return humanObject; }
    }
}
