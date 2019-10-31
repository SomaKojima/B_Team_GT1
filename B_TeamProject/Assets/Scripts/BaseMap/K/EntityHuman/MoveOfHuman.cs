﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOfHuman : MonoBehaviour
{
    const float SPEED = 5.0f;
    /// <summary>
    /// 行動一覧
    /// </summary>
    public enum HUMAN_MOVE
    {
        STOP,
        MOVE,
        COLLECT,
        GO_TO_HOME,

        MOVE_NUM
    }

    public enum TARGET_POSITION_TYPE
    {
        NONE = -1,
        HOME,
        BUILDING_RESOURCE,

        TARGET_POSITION_TYPE_MAX
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

    [SerializeField]
    NavMeshAgent navMeshAgent;

    // 行動パターン
    HUMAN_MOVE moveType = HUMAN_MOVE.COLLECT;

    Vector3 velocity = Vector3.zero;

    TARGET_POSITION_TYPE targetPositionType = TARGET_POSITION_TYPE.BUILDING_RESOURCE;
    Vector3 homePosition = Vector3.zero;
    Vector3 buildingResourcePosition = Vector3.zero;

    BoxCollider box;

    // 資源の場所

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;
        box = gameObject.GetComponent<BoxCollider>();
        //navMeshAgent.speed = SPEED;
    }

    public void Initialize(Vector3 _homePosition, Vector3 _buildingResoucePosition)
    {
        homePosition = _homePosition;
        buildingResourcePosition = _buildingResoucePosition;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += velocity;
        // 移動反転設定
        if (IsTurn(MAX_POS_X, MIN_POS_X, gameObject.transform.position.x, velocity.x))
        {
            velocity = new Vector3(velocity.x * -1, velocity.y, velocity.z);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (IsTurn(MAX_POS_Z, MIN_POS_Z, gameObject.transform.position.z, velocity.z))
        {
            velocity = new Vector3(velocity.x, velocity.y, velocity.z * -1);
        }

        // 目的地に移動
        switch (targetPositionType)
        {
            case TARGET_POSITION_TYPE.HOME:
                navMeshAgent.destination = homePosition;
                break;
            case TARGET_POSITION_TYPE.BUILDING_RESOURCE:
                navMeshAgent.destination = buildingResourcePosition;
                break;
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
    
    // 手前に移動
    void MoveForward()
    {
        velocity = new Vector3(0,0, -SPEED);
    }

    // 奥に移動
    void MoveBackward()
    {
        velocity = new Vector3(0,0, SPEED);
    }

    // 目的の場所に移動する(X軸のみ)
    void MoveXTargetPosition(Vector3 target)
    {
        float x = target.x - gameObject.transform.position.x;

        velocity = new Vector3(SPEED * (x / Mathf.Abs(x)),0,0);
    }
    

    public HUMAN_MOVE MoveType
    {
        get { return moveType; }
    }

    public Vector3 HomePosition
    {
        set { homePosition = value; }
    }

    public Vector3 BuildingResourcePosition
    {
        set { buildingResourcePosition = value; }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        navMeshAgent.updatePosition = true;
        navMeshAgent.nextPosition = gameObject.transform.position;
    }
}
