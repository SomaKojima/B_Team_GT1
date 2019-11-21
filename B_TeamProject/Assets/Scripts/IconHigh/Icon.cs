using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{


    [SerializeField]
    private Image m_image;

    [SerializeField]
    private Text m_text;

    int m_Count=0;

   

    public void Init(int num,Sprite sp)
    {
        //初期化
        m_text.text = "";

        if(m_Count!=0)
        {
            m_text.text = num.ToString();
        }

        m_image.sprite = sp;
       
    }
}
