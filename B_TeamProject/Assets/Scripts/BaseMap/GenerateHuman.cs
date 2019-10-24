using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHuman : MonoBehaviour
{
    // 行動一覧
    public enum HUMAN_MOVE
    {
        STOP,
        MOVE,
        TURN_X,
        TURN_Z,
        COLLECT
    }

    // 活動範囲
    [SerializeField]
    private float MAX_POS_X = 0.0f;
    [SerializeField]
    private float MIN_POS_X = 0.0f;
    [SerializeField]
    private float MAX_POS_Z = 0.0f;
    [SerializeField]
    private float MIN_POS_Z = 0.0f;

    // 木こりのプレハブ
    private GameObject          loggerInstance = null;
    
    // 生活している住人を保存
    private List<GameObject>    humanList = new List<GameObject>();
    private float               humanScele = 0.6f;
    // 生活している住人分の行動を管理
    private List<Vector3>       humanMoveList = new List<Vector3>();
    private List<HUMAN_MOVE>    humanHowToMoveStateList = new List<HUMAN_MOVE>();

    // 住民生成数
    //[SerializeField]
    //private int                 humanStock = 5;

    // 生成位置
    [SerializeField]
    private GameObject          enterPosObj = null;


    // Start is called before the first frame update
    void Start()
    {
        // logger1プレハブをGameObject型で取得
        loggerInstance = (GameObject)Resources.Load("Prefabs/logger1");
    }

    // Update is called once per frame
    void Update()
    {
        // 木こり生成
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenerateLogger(new Vector3(0.1f, 0.0f, 0.1f), HUMAN_MOVE.MOVE);
        }

        // 木こり移動
        MoveLogger();

        // 移動反転設定
        SetStateLoggerToOutOfScreen(MAX_POS_X, MIN_POS_X, MAX_POS_Z, MIN_POS_Z);

        // 移動反転
        MoveTurnLogger();
    }

    /// <summary>
    /// 木こり生成
    /// </summary>
    /// <param name="startMoveDir">動き出す方向</param>
    /// <param name="moveState">初期ステート</param>
    public void GenerateLogger(Vector3 startMoveDir, HUMAN_MOVE moveState)
    {
        // logger1プレハブを元に、インスタンスを生成
        Vector3 pos = enterPosObj.transform.position + new Vector3(0.0f, 0.0f, -1.0f);
        humanList.Add(Instantiate(loggerInstance, pos, Quaternion.identity));
        // このタイミングで生成したオブジェクトの要素を指定
        humanList[humanList.Count - 1].transform.localScale = new Vector3(humanScele, humanScele, 1.0f);

        // 移動オブジェクト生成、初期移動方向を決定
        humanMoveList.Add(startMoveDir);
        // 移動ステート設定
        humanHowToMoveStateList.Add(moveState);
    }

    /// <summary>
    /// 木こりの移動
    /// </summary>
    public void MoveLogger()
    {
        for (int i = 0; i < humanList.Count; i++)
        {
            // 木こり移動
            if (LoggerMoveState[i] == HUMAN_MOVE.MOVE)
            {
                humanList[i].transform.position += humanMoveList[i];
            }

            // 木こり移動方向に向ける(反転処理)
            if (humanMoveList[i].x > 0)
            {
                humanList[i].transform.localScale = new Vector3(-humanScele, humanScele, 1.0f);
            }
            if (humanMoveList[i].x < 0)
            {
                humanList[i].transform.localScale = new Vector3(humanScele, humanScele, 1.0f);
            }
        }
    }

    /// <summary>
    /// 画面外に出ようとしたら反転するように設定
    /// </summary>
    /// <param name="maxPosX">X値最大値</param>
    /// <param name="minPosX">X値最小値</param>
    /// <param name="maxPosZ">Z値最大値</param>
    /// <param name="minPosZ">Z値最小値</param>
    public void SetStateLoggerToOutOfScreen(float maxPosX, float minPosX, float maxPosZ, float minPosZ)
    {
        for (int i = 0; i < humanList.Count; i++)
        {
            // 範囲外に出ようとしたら
            if (humanList[i].transform.position.x > maxPosX || humanList[i].transform.position.x < minPosX)
            {
                // 反転するように設定
                LoggerMoveState[i] = HUMAN_MOVE.TURN_X;
            }
            // 範囲外に出ようとしたら
            if (humanList[i].transform.position.z > maxPosZ || humanList[i].transform.position.z < minPosZ)
            {
                // 反転するように設定
                LoggerMoveState[i] = HUMAN_MOVE.TURN_Z;
            }
        }
    }

    /// <summary>
    /// 反転する状態だったらベクトルを反転する
    /// </summary>
    public void MoveTurnLogger()
    {
        for (int i = 0; i < humanList.Count; i++)
        {
            // 反転する状態化をチェック
            switch (LoggerMoveState[i])
            {
                // X座標の反転だったら
                case HUMAN_MOVE.TURN_X:
                    // ベクトルを反転
                    humanMoveList[i] = new Vector3(-humanMoveList[i].x, humanMoveList[i].y, humanMoveList[i].z);
                    break;
                // Z座標の反転だったら
                case HUMAN_MOVE.TURN_Z:
                    // ベクトルを反転
                    humanMoveList[i] = new Vector3(humanMoveList[i].x, humanMoveList[i].y, -humanMoveList[i].z);
                    break;
                default:
                    break;
            }

            // 移動ステートを更新
            LoggerMoveState[i] = HUMAN_MOVE.MOVE;
        }
    }

    //--------------------Getter,Setter--------------------//
    /// <summary>
    /// 移動ステート取得・設定
    /// </summary>
    public List<HUMAN_MOVE> LoggerMoveState { get { return humanHowToMoveStateList; } set { humanHowToMoveStateList = value; } }

    //-----------------------------------------------------//
}
