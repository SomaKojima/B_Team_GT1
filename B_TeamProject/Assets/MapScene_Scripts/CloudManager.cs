using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CloudManager : MonoBehaviour
{

    [SerializeField]
    //動く速度
    private float m_moveVec;

    //透明化の速さ
    private float speed = 1.0f;

    //フェードするときのカウント
    float m_fadeCount=1.0f;



    [SerializeField]
    private float m_posY;
     
    private float distance_two;


    enum MOVE
    {
        OBJECTLEFTMOVE,
        OBJECTRIGHTMOVE,
        OBJECTLEFTMOVE2,
        OBJECTRIGHTMOVE2,
        FADE,
    }

    [SerializeField]
    MOVE m_state;

    SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        //動きだおおおおおおおおお
        if(m_state==MOVE.OBJECTLEFTMOVE)
        {
            this.transform.position = new Vector3(-4.96f, m_posY, -1.77f);
        }
        else if(m_state==MOVE.OBJECTRIGHTMOVE)
        {
            this.transform.position = new Vector3(-14.67f, m_posY, -1.77f);
        }
        else if(m_state==MOVE.OBJECTLEFTMOVE2)
        {

        }
        else if(m_state==MOVE.OBJECTRIGHTMOVE2)
        {

        }
   
        //スプライトレンダラーを取得
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTransparency(1); // 完全に透明にする

    }

    // Update is called once per frame
    void Update()
    {
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
            case MOVE.FADE:
                m_fadeCount-=0.1f;
                ChangeTransparency(m_fadeCount);
                break;
        }
    }


    void MoveLeft()
    {
        this.transform.DOMove(new Vector3(-14.67f,m_posY, -1.77f), 8.0f);
    }

    void MoveRight()
    {
        this.transform.DOMove(new Vector3(-4.96f, m_posY, -1.77f), 8.0f);
    }

    void MoveLeft2()
    {
        this.transform.DOMove(new Vector3(5.48f,m_posY, -1.77f),8.0f);
    }

    void MoveRight2()
    {
        this.transform.DOMove(new Vector3(15.19f, m_posY, -1.77f), 8.0f);
    }

    void ChangeTransparency(float alpha)
    {
        if (m_state == MOVE.FADE)
        {
            this.spriteRenderer.color = new Color(1, 1, 1, alpha);
        } 
    }
}
