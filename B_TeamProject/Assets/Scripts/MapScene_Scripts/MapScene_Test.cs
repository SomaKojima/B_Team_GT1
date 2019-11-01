using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene_Test : MonoBehaviour
{

    enum BaseName
    {
        Forest,
        Factory,
        Sample1,
        Sample2,
        Sample3,
        Sample4,
    };

    [SerializeField]
    BaseName m_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たり判定をする処理（今はマウスと画像）
    void OnTriggerStay2D(Collider2D col)
    {
        //Forest当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Forest)
        {
            // Debug.Log("forest");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("foresthit");

            }
        }

        //Factory当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Factory)
        {
            // Debug.Log("factory");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("factoryhit");

            }
        }

        //Sample1当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample1)
        {
            // Debug.Log("Sample1");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("sample1hit");

            }
        }

        //Sampl2当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample2)
        {
            // Debug.Log("Sample2");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("sample2hit");

            }
        }

        //Sampl3当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample3)
        {
            // Debug.Log("Sample3");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("sample3hit");

            }
        }

        //Sampl4当たり判定をする処理
        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample4)
        {
            // Debug.Log("Sample4");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("sample4hit");

            }
        }

    }


    //void OnTriggerStay(Collider col)
    //{
    //    //Forest当たり判定をする処理
    //        if (col.gameObject.tag == "Mouse" && m_name == BaseName.Forest)
    //    {
    //        // Debug.Log("forest");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("foresthit");

    //        }
    //    }

    //    //Factory当たり判定をする処理
    //    if (col.gameObject.tag == "Mouse" && m_name == BaseName.Factory)
    //    {
    //        // Debug.Log("factory");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("factoryhit");

    //        }
    //    }

    //    //Sample1当たり判定をする処理
    //    if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample1)
    //    {
    //        // Debug.Log("Sample1");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("sample1hit");

    //        }
    //    }

    //    //Sampl2当たり判定をする処理
    //    if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample2)
    //    {
    //        // Debug.Log("Sample2");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("sample2hit");

    //        }
    //    }

    //    //Sampl3当たり判定をする処理
    //    if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample3)
    //    {
    //        // Debug.Log("Sample3");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("sample3hit");

    //        }
    //    }

    //    //Sampl4当たり判定をする処理
    //    if (col.gameObject.tag == "Mouse" && m_name == BaseName.Sample4)
    //    {
    //        // Debug.Log("Sample4");
    //        if (Input.GetMouseButton(0))
    //        {
    //            Debug.Log("sample4hit");

    //        }
    //    }
    //}
}
