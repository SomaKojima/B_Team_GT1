using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UI_TimeCount : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    [SerializeField]
    int StartTime = 600;
    //個数
    public const int NUM = 4;

    //順位のオブジェクト
    private Image[] m_timer = new Image[NUM];

    //スプライトイメージ
    private Sprite[] m_image_num;

    //カウントダウンするスピード
    [SerializeField]
    float m_speed = 0.1f;

    //スピード設定
    public float Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    public float timeCount { get; private set; }

    float time =0;


    // Start is called before the first frame update
    void Start()
    {
        // リソースをすべてロードする
        m_image_num = Resources.LoadAll<Sprite>("Image/number");

        // 子オブジェクトからコンポーネントを取得する
        m_timer[0] = transform.Find("one").GetComponent<Image>();
        m_timer[1] = transform.Find("ten").GetComponent<Image>();
        m_timer[2] = transform.Find("handred").GetComponent<Image>();
        m_timer[3] = transform.Find("thousand").GetComponent<Image>();

        //10分設定
        //SetTime(600);
        time = StartTime + 1;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 0;
            TimeOver();
        }

        int _time = (int)time - 1;
        if (_time < 0)
        {
            _time = 0;
        }
        int sec = (_time % 60);
        SetNumbers(sec, 2, 3);
        int minu = (_time - sec) / 60;
        SetNumbers(minu, 0, 1);
    }

    //時間を設定する（ここで自由な値に設定）
    public void SetTime(float time)
    {
        timeCount = time;
        StartCoroutine(TimerStart());
    }

    //変換する
    void SetNumbers(int sec, int val1, int val2)
    {
        string str = String.Format("{0:00}", sec);
        m_timer[val1].sprite = m_image_num[Convert.ToInt32(str.Substring(0, 1))];
        m_timer[val2].sprite = m_image_num[Convert.ToInt32(str.Substring(1, 1))];
    }

    //カウントダウンする
    IEnumerator TimerStart()
    {
        //時間がゼロじゃないなら
        while (timeCount >= 0)
        {
            int sec = Mathf.FloorToInt(timeCount % 60);
            SetNumbers(sec, 2, 3);
            int minu = Mathf.FloorToInt((timeCount - sec) / 60);
            SetNumbers(minu, 0, 1);
            yield return new WaitForSeconds(m_speed);
            timeCount -= 1.0f;
        }
        TimeOver();
    }

    //タイムオーバーの処理
    void TimeOver()
    {
        //Debug.Log("timeUp!!!");
        SceneManager.LoadScene(sceneName);
    }
}
