using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class FadeScript : MonoBehaviour
{
    //取得用変数
    bool m_flag=false;

    //フェードインするときのMaterial
    [SerializeField]
    private Material m_transitionOut;

    //フェードアウトするときのMaterial
    [SerializeField]
    private Material m_transitionIn;

    //トランジションする
    [SerializeField]
    private UnityEvent OnTransition;

    //イベントが完了する
    [SerializeField]
    private UnityEvent OnComplete;

    //フェード時間
    [SerializeField]
    private float m_fadeTime = 1.0f;

    GameObject m_cameraChange;

    //マウスダウンの切り替えをする
    bool m_MouseDownflag=false;

    GameObject m_pushButton;

    bool m_pushActiveFlag = false;

  
    void Start()
    {
        //最初はフェードアウトするコルーチンを呼ぶ
       // StartCoroutine(FadeOutTransition());

        m_MouseDownflag = true;

        m_pushButton = GameObject.Find("Cloud");

        m_cameraChange = GameObject.Find("GameObjectAction");

    }

    void Update()
    {

        m_flag = m_cameraChange.GetComponent<Camera_Change>().Flag;

        //フラグがオンになったら
        if (m_flag)
        {
            StartCoroutine(InTransition());
        }

        m_pushActiveFlag = m_pushButton.GetComponent<CloudMove>().OneLoopFlag;


        if (m_pushActiveFlag)
        {
            this.GetComponent<UnityEngine.UI.Image>().enabled = true;
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }

    }


    //フェードアウトするコルーチン
    IEnumerator FadeOutTransition()
    {
        yield return Animate(m_transitionOut, 1);
        if (OnTransition != null) { OnTransition.Invoke();}

        yield return new WaitForEndOfFrame();
    }

    //フェードインするコルーチン
    IEnumerator InTransition()
    {
        yield return Animate(m_transitionIn, m_fadeTime);
        if (OnComplete != null) { OnComplete.Invoke(); }

        yield return new WaitForEndOfFrame();

        StartCoroutine(FadeOutTransition());
    }

   
    /// <summary>
    /// time秒かけてトランジションを行う
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator Animate(Material material, float time)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);
    }


    //フェードアウトする
    public void FadeOut()
    {
        StartCoroutine(FadeOutTransition());
    }


    //フェードインする
    public void FadeIn()
    {
        StartCoroutine(InTransition());
    }

}
