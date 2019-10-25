using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    [SerializeField]
    private GameObject m_mainCamera;

    [SerializeField]
    private GameObject m_subCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_mainCamera.SetActive(!m_mainCamera.activeSelf);
            m_subCamera.SetActive(!m_subCamera.activeSelf);
        }
    }
}
