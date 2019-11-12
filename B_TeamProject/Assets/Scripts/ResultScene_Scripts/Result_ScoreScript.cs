using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Result_ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    //定数
    //個数
    public const int NUM = 4;

    //順位のオブジェクト
    private GameObject[] m_ranking = new GameObject[NUM];

    //ソートの値を取得
    int[] m_valueBox = new int[NUM];

   

    // スプライトを格納する変数
    [SerializeField]
    private Sprite[] m_image_num;

    // 子オブジェクト
    private Image m_one;
    private Image m_ten;
    private Image m_handred;
    private Image m_thousand;
    private Image m_tenthousand;


    // スコア 
    [SerializeField]
    private int m_score;
    private int m_tmpScore = 0;

    [SerializeField]
    private Text m_scoreText = null;

    // スコアの取得と設定
    public int Score { get { return m_score; } set { m_score = value; } }


    // Start is called before the first frame update
    void Start()
    {
        // リソースをすべてロードする
        m_image_num = Resources.LoadAll<Sprite>("Image/number");

        // 子オブジェクトからコンポーネントを取得する
        m_one = transform.Find("one").GetComponent<Image>();
        m_ten = transform.Find("ten").GetComponent<Image>();
        m_handred = transform.Find("handred").GetComponent<Image>();
        m_thousand = transform.Find("thousand").GetComponent<Image>();
        m_tenthousand = transform.Find("tenthousand").GetComponent<Image>();


        // スコアを設定する
        m_scoreText = transform.Find("Text").GetComponent<Text>();
        // スコアが０より小さいなら処理しない
        if (m_score < 0) return;

        m_scoreText.text = m_score.ToString();
    }

   // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    //ソートする関数（出来てる確証なし）
    public void Judge(Dictionary<int, int> info)
    {
        //ソートする奴
        var sort = info.OrderByDescending(keySelector => keySelector.Value);

        foreach (KeyValuePair<int, int> kvp in sort)
        {
            // Debug.Log(kvp.Key);

            for (int i = 0; i < NUM; i++)
            {
                m_valueBox[i] = kvp.Value;
            }

            //Debug.Log(m_valueBox);

        }
    }


    //スコアを画像に設定
    void SetScore()
    {
        // ローカル変数にスコアを入れる
        int tmp = m_score;
        // 一の位のスコアを設定する
        m_one.sprite = m_image_num[tmp % 10];
        // 桁を進める
        tmp /= 10;
        //十の位のスコアを設定する
        m_ten.sprite = m_image_num[tmp % 10];
        tmp /= 10;
        // 百の位のスコアを設定する
        m_handred.sprite = m_image_num[tmp % 10];
        tmp /= 10;
        //千の位のスコアを設定する
        m_thousand.sprite = m_image_num[tmp % 10];
        //万の位のスコアを設定する
        m_tenthousand.sprite = m_image_num[tmp / 10];

    }

}
