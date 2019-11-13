using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloudMove2 : MonoBehaviour
{
    List<CloudMove> clouds = new List<CloudMove>();
    
    [SerializeField]
    FadeScript fadescript;

    [SerializeField]
    Image image;

    [SerializeField, Range(0.0f, 10.0f)]
    float fadeTime = 1.0f;

    bool isFirstProcess = true;
    bool isIn = false;

    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    public void Initialize()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            CloudMove move = transform.GetChild(i).GetComponent<CloudMove>();
            if (move != null)
            {
                clouds.Add(move);
            }
        }
    }

    public IEnumerator FadeOut()
    {
        if (isIn)
        {
            isIn = false;
            isFirstProcess = true;
        }
        if (isFirstProcess)
        {
            StartCoroutine(fadescript.FadeOutTransition(fadeTime));
            isFirstProcess = false;
        }
           
        foreach (CloudMove move in clouds)
        {
            move.MoveToOutPos(fadeTime);
        }

        if (!IsProcess)
        {
            image.raycastTarget = false;
        }
        yield return new WaitForEndOfFrame();
    }


    public IEnumerator FadeIn()
    {
        if (!isIn)
        {
            isIn = true;
            isFirstProcess = true;
        }
        if (isFirstProcess)
        {
            StartCoroutine(fadescript.InTransition(fadeTime));
            isFirstProcess = false;
        }

        image.raycastTarget = true;

        foreach (CloudMove move in clouds)
        {
            move.MoveToInPos(fadeTime);
        }

        yield return new WaitForEndOfFrame();

        //StartCoroutine(FadeOut());
    }
    
    public bool IsProcess
    {
        get { return fadescript.IsProcess; }
    }
}
