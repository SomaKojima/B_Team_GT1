using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //マップ上のオブジェクト個数
    public const int MAP_BASE_NUM = 7;

    //マップ上のオブジェクト
    private GameObject[] m_mapObject = new GameObject[MAP_BASE_NUM];

    // Start is called before the first frame update
    void Start()
    {

        //Texture配列
        Sprite[] m_sprite = {
            Resources.Load<Sprite>("Map"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest"),
            Resources.Load<Sprite>("Forest")};

        //森林テクスチャのロード
       // Sprite ForestSprite = Resources.Load<Sprite>("Forest");

        for(int i=0;i<MAP_BASE_NUM;i++)
        {
            //タイトルのロゴを生成
            m_mapObject[i] = new GameObject("Base" + i);
            //スプライトレンダラーをAddする
            m_mapObject[i].AddComponent<SpriteRenderer>();
            //リジットを追加
            m_mapObject[i].AddComponent<Rigidbody2D>();
            //当たり判定を追加
            m_mapObject[i].AddComponent<CircleCollider2D>();
            //重力を０にする
            m_mapObject[i].GetComponent<Rigidbody2D>().gravityScale = 0;
            //描画順を変更
            m_mapObject[i].GetComponent<SpriteRenderer>().sortingOrder = 1;

            //森テクスチャをコンポーネント
            m_mapObject[i].GetComponent<SpriteRenderer>().sprite = m_sprite[i];

            //m_mapObject[i].transform.position = Instantiate(gameObject);
        }
        

       

        //森テクスチャのポジション
        m_mapObject[0].transform.position = new Vector3(0, 0, 0);

        //マップのスケールを拡大させる
        m_mapObject[0].transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

        //マップの回転値の変更
        m_mapObject[0].transform.transform.rotation = Quaternion.Euler(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
