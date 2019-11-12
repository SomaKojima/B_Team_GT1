using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Result_Script : MonoBehaviour
{

    //クリック
    bool m_clickFlag = false;


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void OnClick()
    {
        m_clickFlag = true;
    }

    public void OnClickProcess()
    {
        m_clickFlag = false;
    }

    public void BackTitle()
    {

    }
        
}
   