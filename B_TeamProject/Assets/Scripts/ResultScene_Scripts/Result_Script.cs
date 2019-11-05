using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Result_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public const int NUM = 4;

    Sprite m_one;
    Sprite m_two;
    Sprite m_three;
    Sprite m_four;

    //順位のオブジェクト
    private GameObject[] m_ranking = new GameObject[NUM];

    //ソートの値を取得
    int[] m_valueBox = new int[NUM];





    //順位を紐づける
    enum Ranking
    {
        One,
        Two,
        Three,
        Four,

        Rank_Num
    }

    Ranking m_rank;

    //テスト用変数
    Dictionary<int, int> m_test = new Dictionary<int, int>()
    {
        {1, 6},
        {2, 3},
        {3, 2},
        {4, 5},
    };


    bool m_clickFlag = false;


    void Start()
    {

        Sprite[] m_sprite =
        {
            Resources.Load<Sprite>("Sprite\\Result\\gold_medal"),
            Resources.Load<Sprite>("Sprite\\Result\\medal_silver"),
            Resources.Load<Sprite>("Sprite\\Result\\medal_bronze"),
            Resources.Load<Sprite>("Sprite\\Result\\medal_light_blue")
         };

        for (int i=0;i< NUM; i++)
        {
            m_ranking[i] = new GameObject("ranking" + i);

            //オブジェクトにスプライトレンダラーを追加
            m_ranking[i].AddComponent<SpriteRenderer>();

            //オブジェクトにスプライトを貼り付ける
            //m_ranking[i].GetComponent<SpriteRenderer>().sprite = m_sprite[i]; 


           // m_valueBox[i];


        }

    }

    public void Onclick()
    {
        m_clickFlag = true;
    }

    public void OnClickProcess()
    {
        m_clickFlag = false;
    }


    // Update is called once per frame
    void Update()
    {

        Judge(m_test);


        //for (int i = 0; i < NUM; i++)
        //{
        //    m_valueBox[i]
        //}


        switch (m_rank)
        {
            case Ranking.One:
                m_ranking[0].SetActive(true);
                break;
            case Ranking.Two:
                m_ranking[1].SetActive(true);
                break;
            case Ranking.Three:
                m_ranking[2].SetActive(true);
                break;
            case Ranking.Four:
                m_ranking[3].SetActive(true);
                break;
        }

    }

    //ソートする関数（出来てる確証なし）
    public void Judge(Dictionary<int,int> info)
    {
        //ソートする奴
        var sort = info.OrderByDescending(keySelector => keySelector.Value);

        foreach (KeyValuePair<int, int> kvp in sort)
        {
           // Debug.Log(kvp.Key);

            for(int i=0;i<NUM;i++)
            {
                m_valueBox[i] = kvp.Value;
            }

            //Debug.Log(m_valueBox);
           
        }
    }
  

}
