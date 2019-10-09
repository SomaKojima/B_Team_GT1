using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //マップ自体の大きさ
    [SerializeField]
    private float m_mapScale = 0.0f;

    //テクスチャの基準となるポジション
    private Vector3 m_texPos = new Vector3(0, 0, 0);
    
    //マップ上のオブジェクト個数
    public const int MAP_BASE_NUM = 7;

    //マップ上のオブジェクト
    private GameObject[] m_mapObject = new GameObject[MAP_BASE_NUM];

    // Start is called before the first frame update
    void Start()
    {

        //テクスチャ配列
        Sprite[] m_sprite = {
            Resources.Load<Sprite>("phone_map"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest")};


        for(int i=0;i<MAP_BASE_NUM;i++)
        {
            //タイトルのロゴを生成
            m_mapObject[i] = new GameObject("Base" + i);
            //スプライトレンダラーをAddする
            m_mapObject[i].AddComponent<SpriteRenderer>();
            //描画順を変更
            m_mapObject[i].GetComponent<SpriteRenderer>().sortingOrder = 1;

            //森テクスチャをコンポーネント
            m_mapObject[i].GetComponent<SpriteRenderer>().sprite = m_sprite[i];

            //m_mapObject[i].transform.position = Instantiate(gameObject);
        }
       

        for(int i=1;i< MAP_BASE_NUM;i++)
        {
            //画像の大きさを調整する
            m_mapObject[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //リジットを追加
            m_mapObject[i].AddComponent<Rigidbody2D>();
            //当たり判定を追加
            m_mapObject[i].AddComponent<CircleCollider2D>();
            //重力を０にする
            m_mapObject[i].GetComponent<Rigidbody2D>().gravityScale = 0;
            
            //描画順を変更
            m_mapObject[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        //ポジションの細かい設定
        m_mapObject[1].transform.position = m_texPos+ new Vector3(0, -1.73f,0);

        m_mapObject[2].transform.position = m_texPos + new Vector3(0.21f, 5.24f, 2.9f);

        m_mapObject[3].transform.position= m_texPos + new Vector3(3.7f, 0.9f, 1.77f);

        m_mapObject[4].transform.position = m_texPos + new Vector3(-3.6f, -6.6f, -0.28f);
        m_mapObject[4].transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        m_mapObject[5].transform.position = m_texPos + new Vector3(3.2f, -5.23f, -1.09f);
        m_mapObject[5].transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        m_mapObject[6].transform.position = m_texPos + new Vector3(-3.5f, 2.3f, 1.68f);


        //マップのスケールを拡大させる
        m_mapObject[0].transform.localScale = new Vector3(m_mapScale, m_mapScale, m_mapScale);

        //マップの回転値の変更
        m_mapObject[0].transform.transform.rotation = Quaternion.Euler(37.426f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Camera.main.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Camera")
        {
            Debug.Log("jhfhe");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("jhfhe");
                //SceneManager.LoadScene("GameScene");
            }
        }
    }
}
