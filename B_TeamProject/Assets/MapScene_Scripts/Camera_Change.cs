using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Camera_Change : MonoBehaviour
{
    //メインカメラ
    [SerializeField]
    private GameObject m_mainCamera;

    //サブカメラ
    [SerializeField]
    private GameObject m_subCamera;

    //ボタンを押したら
    bool m_flag;
    
    // Start is called before the first frame update
    void Start()
    {
        //m_cloud[5].GetComponent<CloudMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //アクティブを切り替える
            m_flag = true;
            m_mainCamera.SetActive(!m_mainCamera.activeSelf);
            m_subCamera.SetActive(!m_subCamera.activeSelf);
        }
        else
        {
            m_flag = false;
        }
    }


    //フラグの取得、設定
    public bool Flag
    {
        get { return m_flag; }
        set { m_flag = value; }
    }
}
