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
    //[SerializeField]
   // private UnityEvent OnTransition;

    //イベントが完了する
    //[SerializeField]
   // private UnityEvent OnComplete;

    //フェード時間
    [SerializeField]
    private float m_fadeTime = 1.0f;


    void Start()
    {
        //最初はフェードアウトするコルーチンを呼ぶ
        //this.gameObject.SetActive(false);

        StartCoroutine(Fade());

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(InTransition());
        }
       

    }



    //public IEnumerator Fade()
    //{


    //    StartCoroutine(InTransition());



    //    StartCoroutine(FadeOutTransition());

    //    yield return new WaitForEndOfFrame();
    //}

    public IEnumerator Fade()
    {
        this.gameObject.SetActive(true);
        yield return Animate(m_transitionIn, m_fadeTime);
       // if (OnComplete != null) { OnComplete.Invoke(); }

        yield return new WaitForEndOfFrame();

        //  StartCoroutine(FadeOutTransition());
        yield return Animate(m_transitionOut, 1);
        //if (OnTransition != null) { OnTransition.Invoke(); }

        yield return new WaitForEndOfFrame();
        this.gameObject.SetActive(false);

    }

    //フェードアウトするコルーチン
    public IEnumerator FadeOutTransition()
    {
        this.gameObject.SetActive(true);
        yield return Animate(m_transitionOut, 1);
        //if (OnTransition != null) { OnTransition.Invoke(); }

        yield return new WaitForEndOfFrame();
       this.gameObject.SetActive(false);
    }

    //フェードインするコルーチン
    public IEnumerator InTransition()
    {
       
        yield return Animate(m_transitionIn, m_fadeTime);
        //if (OnComplete != null) { OnComplete.Invoke(); }

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


    //フェードアウトする



}
