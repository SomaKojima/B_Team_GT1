using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CloudMove : MonoBehaviour
{
    [SerializeField]
    RectTransform image;

    [SerializeField]
    RectTransform outPos;

    [SerializeField]
    RectTransform inPos;

    Vector3 inPosBuf;
    Vector3 outPosBuf;

    float time = 0;
    float duringTime = 1.0f;
    bool isIn = false;
    bool isEndFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        inPosBuf = inPos.localPosition;
        outPosBuf = outPos.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndFlag != isIn)
        {
            time = 0.0f;
        }

        float t = CulcT();

        if (isIn)
        {
            image.localPosition = Vector3.Lerp(image.localPosition, inPosBuf, t);
        }
        else
        {
            image.localPosition = Vector3.Lerp(image.localPosition, outPosBuf, t);
        }
        time += Time.deltaTime;

        if (CulcT() >= 1.0f)
        {
            time = duringTime;
        }
        isEndFlag = isIn;
    }

    float CulcT()
    {
        if (duringTime == 0.0f)
        {
           return 1.0f;
        }
        else
        {
            return time / duringTime;
        }
    }

    public void MoveToInPos(float _time)
    {
        duringTime = _time;
        isIn = true;
    }

    public void MoveToOutPos(float _time)
    {
        duringTime = _time;
        isIn = false;
    }
}
