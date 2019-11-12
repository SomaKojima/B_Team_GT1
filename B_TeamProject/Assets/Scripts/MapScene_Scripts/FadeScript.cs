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


    bool isProcess = false;

    void Start()
    {

        //StartCoroutine(Fade());

    }
    
    //フェードアウトするコルーチン
    public IEnumerator FadeOutTransition(float time)
    {
        isProcess = true;
        yield return Animate(m_transitionOut, time);
        //if (OnTransition != null) { OnTransition.Invoke(); }

        yield return new WaitForEndOfFrame();
    }

    //フェードインするコルーチン
    public IEnumerator InTransition(float time)
    {
        isProcess = true;
         yield return Animate(m_transitionIn, time);
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
        isProcess = false;
    }


    //フェードアウトする

    public bool IsProcess
    {
        get { return isProcess; }
    }

}
