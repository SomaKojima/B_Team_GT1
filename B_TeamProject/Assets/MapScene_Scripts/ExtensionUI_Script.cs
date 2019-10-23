using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionUI_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject m_extension;

    [SerializeField]
    private GameObject m_sample;

    // Start is called before the first frame update
    void Start()
    {

        m_extension.SetActive(false);
        m_sample.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick()
    {
        m_extension.SetActive(true);
        m_sample.SetActive(true);
    }
}
