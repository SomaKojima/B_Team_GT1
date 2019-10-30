using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfHuman : MonoBehaviour
{
    /// <summary>
    /// 行動一覧
    /// </summary>
    public enum HUMAN_MOVE
    {
        STOP,
        MOVE,
        COLLECT,

        MOVE_NUM
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

    // 行動パターン
    HUMAN_MOVE moveType = HUMAN_MOVE.STOP;

    Vector3 velocity = new Vector3(0.1f, 0.0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += velocity;
        // 移動反転設定
        if (IsTurn(MAX_POS_X, MIN_POS_X, gameObject.transform.position.x, velocity.x))
        {
            velocity = new Vector3(velocity.x * -1, velocity.y, velocity.z);
            gameObject.transform.localScale
        }
        else if (IsTurn(MAX_POS_Z, MIN_POS_Z, gameObject.transform.position.z, velocity.z))
        {
            velocity = new Vector3(velocity.x, velocity.y, velocity.z * -1);
        }
    }

    /// <summary>
    /// 画面外に出ようとしたら反転するように設定
    /// </summary>
    /// <param name="maxPosX">X値最大値</param>
    /// <param name="minPosX">X値最小値</param>
    /// <param name="maxPosZ">Z値最大値</param>
    /// <param name="minPosZ">Z値最小値</param>
    public bool IsTurn(float maxPos, float minPos, float position, float velocity)
    {
        // 範囲外に出ようとしたら
        if (position > maxPos && velocity > 0)
        {
            // 反転するように設定
            return true;
        }
        else if(position < minPos && velocity < 0)
        {
            return true;
        }
        return false;
    }

    public HUMAN_MOVE MoveType
    {
        get { return moveType; }
    }
}
