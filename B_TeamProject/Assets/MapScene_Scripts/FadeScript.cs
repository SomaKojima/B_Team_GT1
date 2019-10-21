using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class FadeScript : MonoBehaviour
{
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

    //マウスダウンの切り替えをする
    bool m_MouseDownflag;



    void Start()
    {
        //最初はフェードアウトするコルーチンを呼ぶ
        StartCoroutine(FadeOutTransition());

        m_MouseDownflag = true;
    }

    void Update()
    {

        //マウスボタンをを押したら
        if (Input.GetMouseButtonDown(0))
        {
            m_MouseDownflag = !m_MouseDownflag;
            if (m_MouseDownflag)
            {
                StartCoroutine(FadeOutTransition());
            }
            else
            {
                StartCoroutine(InTransition());
            }
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
}
