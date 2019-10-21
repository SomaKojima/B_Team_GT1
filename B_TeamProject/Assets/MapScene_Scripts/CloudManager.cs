using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CloudManager : MonoBehaviour
{
    [SerializeField]
    private float m_posY;

    //雲の動き  
    enum MOVE
    {
        OBJECTLEFTMOVE,     //画面内から画面外へ
        OBJECTRIGHTMOVE,    //画面外から画面内へ
        OBJECTLEFTMOVE2,    //画面外から画面内へ
        OBJECTRIGHTMOVE2,   //画面内から画面外へ
    }

    [SerializeField]
    MOVE m_state;

    // Start is called before the first frame update
    void Start()
    {
        if(m_state==MOVE.OBJECTLEFTMOVE)
        {
            this.transform.position = new Vector3(-4.96f, m_posY, -1.77f);
        }
        else if(m_state==MOVE.OBJECTRIGHTMOVE)
        {
            this.transform.position = new Vector3(-14.67f, m_posY, -1.77f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //動きの分岐
        switch (m_state)
        {
            case MOVE.OBJECTLEFTMOVE:
                MoveLeft();
                break;
            case MOVE.OBJECTRIGHTMOVE:
                MoveRight();
                break;
            case MOVE.OBJECTLEFTMOVE2:
                MoveLeft2();
                break;
            case MOVE.OBJECTRIGHTMOVE2:
                MoveRight2();
                break;
        }

        //動いた反対方向へ動く処理
        if (Input.GetMouseButtonDown(0))
        {
            if (m_state == MOVE.OBJECTLEFTMOVE)
            {
                m_state = MOVE.OBJECTRIGHTMOVE;
            }
            else if (m_state == MOVE.OBJECTRIGHTMOVE)
            {
                m_state = MOVE.OBJECTLEFTMOVE;
            }
            else if (m_state == MOVE.OBJECTLEFTMOVE2)
            {
                m_state = MOVE.OBJECTRIGHTMOVE2;
            }
            else if (m_state == MOVE.OBJECTRIGHTMOVE2)
            {
                m_state = MOVE.OBJECTLEFTMOVE2;
            }
        }

      

    }

    //左側の雲（画面内から画面外へ）
    void MoveLeft()
    {
        this.transform.DOMove(new Vector3(-14.67f,m_posY, -1.77f), 8.0f);
    }

    //左側の雲（画面外から画面内へ）
    void MoveRight()
    {
        this.transform.DOMove(new Vector3(-4.96f, m_posY, -1.77f), 8.0f);
    }

    //右側の雲（画面外から画面内へ）
    void MoveLeft2()
    {
        this.transform.DOMove(new Vector3(5.48f,m_posY, -1.77f),8.0f);
    }

    //右側の雲（画面内から画面外へ）
    void MoveRight2()
    {
        this.transform.DOMove(new Vector3(15.19f, m_posY, -1.77f), 8.0f);
    }
}
