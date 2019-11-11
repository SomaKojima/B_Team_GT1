using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CloudMove : MonoBehaviour
{

    private Image m_cloudL;
    private Image m_cloud2L;
    private Image m_cloud3L;
    private Image m_cloud4R;
    private Image m_cloud5R;


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
  //  GameObject m_cameraChange;

    enum Type
    {
        Change,
        FadeOut,
        FadeIn,
    }

    [SerializeField]
    Type m_usetype;

    //enum MoveType
    //{
    //    Left,
    //    Right,
    //}

    //[SerializeField]
    //MoveType m_movetype;

    //雲が動く回数
    int m_Count = 0;

    //一往復フラグ
    bool m_oneroopFlag = false;

    [SerializeField]
    bool m_directionFlag;

    // Start is called before the first frame update
    void Start()
    {
        m_rect = GetComponent<RectTransform>();

        //m_cameraChange = GameObject.Find("GameObjectAction");


        // 子オブジェクトからコンポーネントを取得する
        m_cloudL = transform.Find("Cloud").GetComponent<Image>();
        m_cloud2L = transform.Find("Cloud (2)").GetComponent<Image>();
        m_cloud3L = transform.Find("Cloud (3)").GetComponent<Image>();
        m_cloud4R = transform.Find("Cloud (1)").GetComponent<Image>();
        m_cloud5R = transform.Find("Cloud (4)").GetComponent<Image>();


        if (m_fadeFlag)
        {

            m_cloudL.rectTransform.localPosition= new Vector3(-336f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);

            m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);

            //if (m_movetype == MoveType.Left)
            //{
            //    m_rect.localPosition = new Vector3(-336f, m_posY, 0);
            //}
            //else if (m_movetype == MoveType.Right)
            //{
            //    m_rect.localPosition = new Vector3(347f, m_posY, 0);
            //}
        }


        //if (m_usetype == Type.FadeIn)
        //{
        //    if (m_movetype == MoveType.Left)
        //    {
        //        m_rect.localPosition = new Vector3(-1089f, m_posY, 0);
        //    }
        //    else if (m_movetype == MoveType.Right)
        //    {
        //        m_rect.localPosition = new Vector3(1100f, m_posY, 0);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

        FadeOut();
        //カメラでボタンを押したときにオンになったフラグ
       // m_cameraflag = m_cameraChange.GetComponent<Camera_Change>().Flag;

        //カメラ切り替えボタンを押したら
        //if (m_cameraflag)
        //{
        //    m_oneroopFlag = true;
        //   this.GetComponent<UnityEngine.UI.Image>().enabled = true;
        //}


        //switch (m_usetype)
        //{
        //    case Type.Change:
        //        if (m_movetype == MoveType.Left)
        //        {
        //            MoveCloud(-1089f, -336f);
        //        }
        //        if (m_movetype == MoveType.Right)
        //        {
        //            MoveCloud(347f, 1100f);
        //        }
        //        break;
        //    case Type.FadeOut:
        //        CloudFadeOut(-1089f, 1100f);
        //        break;
        //    case Type.FadeIn:
        //        CloudFadeIn(347f ,- 336f);
        //        break;

        //}


        

       

    }

    bool m_fadeFlag = false;
    public void FadeOut()
    {

        m_cloudL.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud2L.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud3L.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud4R.rectTransform.localPosition += new Vector3(20, 0, 0);
        m_cloud5R.rectTransform.localPosition += new Vector3(20, 0, 0);

        if (m_cloudL.rectTransform.localPosition.x <= -1089f)
        {
            m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);

        }

        if(m_cloud4R.rectTransform.localPosition.x>= 1100f)
        {
            m_cloud4R.rectTransform.localPosition=new Vector3(1100f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);
        }

      

        m_fadeFlag = true;

    }


    //雲
   

   //フェードアウトする
    public void CloudFadeOut(float left_target_posX,float right_target_posX)
    {
        this.GetComponent<UnityEngine.UI.Image>().enabled = true;

        if (m_directionFlag)
        {
            //trueなら左に動く
           // 

            m_rect.localPosition -= new Vector3(20, 0, 0);

            if (m_rect.localPosition.x <= left_target_posX)
            {
                m_rect.localPosition = new Vector3(left_target_posX, m_posY, 0);

            }
        }
        else
        {
            //falseなら右に動く
           // 

            m_rect.localPosition += new Vector3(20, 0, 0);

            if (m_rect.localPosition.x >= right_target_posX)
            {
                m_rect.localPosition = new Vector3(right_target_posX, m_posY, 0);
            }
        }

    }

    //フェードインする
    public void CloudFadeIn(float right_target_posX, float left_target_posX)
    {
        this.GetComponent<UnityEngine.UI.Image>().enabled = true;


        if (m_directionFlag)
        {
            //trueなら右に動く
           
            m_rect.localPosition += new Vector3(20, 0, 0);

            if (m_rect.localPosition.x >= left_target_posX)
            {
                m_rect.localPosition = new Vector3(left_target_posX, m_posY, 0);

            }
        }
        else
        {
            //falseなら左に動く

            m_rect.localPosition -= new Vector3(20, 0, 0);

            if (m_rect.localPosition.x <= right_target_posX)
            {
                m_rect.localPosition = new Vector3(right_target_posX, m_posY, 0);
            }
        }
    }
    


    //ワンループしてる時のフラグ
    public bool OneLoopFlag
    {
        get { return m_oneroopFlag; }
        set { m_oneroopFlag = value; }
    }

}
