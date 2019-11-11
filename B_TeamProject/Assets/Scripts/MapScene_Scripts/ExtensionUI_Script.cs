using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionUI_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject m_extension = null;

    [SerializeField]
    private GameObject m_sample = null;

    //アクティブフラグ
    bool m_active;

    //ボタンを押したら
    bool m_clickFlag;

    // Start is called before the first frame update
    void Start()
    {
        m_active = false;
        m_extension.SetActive(m_active);
        m_sample.SetActive(m_active);
        
    }

    // Update is called once per frame
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

    //ボタン
    public void MenuClick()
    {
        m_active = !m_active;

        Debug.Log("buttonがおされたよ");

        if (m_active)
        {
            m_extension.SetActive(true);
            m_sample.SetActive(true);
        }
        else
        {
            m_extension.SetActive(false);
            m_sample.SetActive(false);
        }
    }


    //増築ボタンを押したら
    public void ExtensionClick()
    {
        Debug.Log("増築でございます");
    }

    //サンプルボタンを押したら
    public void SampleClick()
    {
        Debug.Log("サンプル");
    }

}
