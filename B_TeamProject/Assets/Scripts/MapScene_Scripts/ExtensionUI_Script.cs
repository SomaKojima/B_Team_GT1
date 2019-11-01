using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionUI_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject m_extension;

    [SerializeField]
    private GameObject m_sample;

    //アクティブフラグ
    bool m_active;

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
        m_active = !m_active;

        Debug.Log("grigir");

        if(m_active)
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
        Debug.Log("rara");
    }

    //サンプルボタンを押したら
    public void SampleClick()
    {
        Debug.Log("sample");
    }

}
