using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CloudMove : MonoBehaviour
{
    //レクトトランスフォーム
    RectTransform m_rect;

    //カメラの切り替えたときの取得フラグ
    bool m_cameraflag;

    //ポジション
    [SerializeField]
    float m_posY=0.0f;


    //どっちから動くか
    [SerializeField]
    private bool m_moveFlag;

    //カメラオブジェクト
    GameObject m_cameraChange;


    enum MoveType
    {
        Left,
        Right,
    }

    [SerializeField]
    MoveType m_movetype;

    //雲が動く回数
    int m_Count = 0;

    //一往復フラグ
    bool m_oneroopFlag = false;

    [SerializeField]
    bool m_flag;

    // Start is called before the first frame update
    void Start()
    {
        m_rect = GetComponent<RectTransform>();

        m_cameraChange = GameObject.Find("GameObjectAction");

    }

    // Update is called once per frame
    void Update()
    {
        //カメラでボタンを押したときにオンになったフラグ
        m_cameraflag = m_cameraChange.GetComponent<Camera_Change>().Flag;

        //カメラ切り替えボタンを押したら
        if (m_cameraflag)
        {
            m_oneroopFlag = true;
            this.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }

       
        if (m_movetype == MoveType.Left)
        {
            MoveCloud(-1089f, -336f);
        }
        if (m_movetype == MoveType.Right)
        {
            MoveCloud(347f, 1100f);
        }
    }

   

    //雲
    void MoveCloud(float posX,float target_posX)
    {
        //一往復フラグがオンになったら
        if(m_oneroopFlag)
        {
            if (m_moveFlag)
            {
                m_rect.localPosition -= new Vector3(20, 0, 0);
            }
            else
            {
                m_rect.localPosition += new Vector3(15, 0, 0);
            }
        }
     
   
        //左に動く
        if (m_rect.localPosition.x <= posX)
        {
            m_rect.localPosition = new Vector3(posX, m_posY, 0);
            m_moveFlag = false;
            m_Count += 1;
        }

        

        //右に動く
        if (m_rect.localPosition.x >= target_posX)
        {
            m_rect.localPosition = new Vector3(target_posX, m_posY, 0);
            m_moveFlag = true;
            m_Count += 1;

        }

        //一往復となったら
        if (m_Count>=2)
        {
            if (m_movetype == MoveType.Left)
            {
                m_rect.localPosition = new Vector3(posX, m_posY, 0);
            }
            if (m_movetype == MoveType.Right)
            {
                m_rect.localPosition = new Vector3(target_posX, m_posY, 0);
            }

            m_oneroopFlag = false;

        }

        //一往復終わったらカウントをリセットする
        if (m_oneroopFlag==false)
        {
            m_Count = 0;
            this.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }

    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    //ワンループしてる時のフラグ
    public bool OneLoopFlag
    {
        get { return m_oneroopFlag; }
        set { m_oneroopFlag = value; }
    }

}
