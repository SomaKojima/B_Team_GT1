using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloudMove2 : MonoBehaviour
{
    bool m_fadeFlag = false;

    private Image m_cloudL;
    private Image m_cloud2L;
    private Image m_cloud3L;
    private Image m_cloud4R;
    private Image m_cloud5R;
  
    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトからコンポーネントを取得する
        m_cloudL = transform.Find("Cloud").GetComponent<Image>();
        m_cloud2L = transform.Find("Cloud (2)").GetComponent<Image>();
        m_cloud3L = transform.Find("Cloud (3)").GetComponent<Image>();
        m_cloud4R = transform.Find("Cloud (1)").GetComponent<Image>();
        m_cloud5R = transform.Find("Cloud (4)").GetComponent<Image>();
       
        //if (m_fadeFlag)
        //{

        //    m_cloudL.rectTransform.localPosition = new Vector3(-336f, -58, 0);
        //    m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
        //    m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);

        //    m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
        //    m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);
        //}
        //else
        //{
        //    m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
        //    m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
        //    m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);

        //    m_cloud4R.rectTransform.localPosition = new Vector3(1100f, -422, 0);
        //    m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);

        //}
    }

    bool m_outStart = false;
    bool m_inStart=false;
    float m_time;

    bool m_oneloop=false;

    int m_Count = 1;

    IEnumerator FadeOut()
    {
        m_time += Time.deltaTime;


        if(m_time>0.5f)
        {
            m_outStart = true;
        }

        if(!m_outStart)
        {
            m_cloudL.rectTransform.localPosition = new Vector3(-336f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);

            m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);
        }
     

        m_cloudL.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud2L.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud3L.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud4R.rectTransform.localPosition += new Vector3(20, 0, 0);
        m_cloud5R.rectTransform.localPosition += new Vector3(20, 0, 0);

        if (m_cloudL.rectTransform.localPosition.x <= -1089f)
        {
            m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);

        }

        if (m_cloud4R.rectTransform.localPosition.x >= 1100f)
        {
            m_cloud4R.rectTransform.localPosition = new Vector3(1100f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);
        }

        yield return new WaitForEndOfFrame();
    }


    IEnumerator FadeIn()
    {
        m_fadeFlag = false;

        m_time += Time.deltaTime;

        if (m_time > 0.5f)
        {
            m_inStart = true;
        }

        if(!m_inStart)
        {
            m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);

            m_cloud4R.rectTransform.localPosition = new Vector3(1100f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);
        }

        m_cloudL.rectTransform.localPosition += new Vector3(20, 0, 0);
        m_cloud2L.rectTransform.localPosition += new Vector3(20, 0, 0);
        m_cloud3L.rectTransform.localPosition += new Vector3(20, 0, 0);
        m_cloud4R.rectTransform.localPosition -= new Vector3(20, 0, 0);
        m_cloud5R.rectTransform.localPosition -= new Vector3(20, 0, 0);

        if (m_cloud4R.rectTransform.localPosition.x <= 196f)
        {
            m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
            m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);

        }

        if (m_cloudL.rectTransform.localPosition.x >= -336f)
        {
            m_cloudL.rectTransform.localPosition = new Vector3(-336f, -58, 0);
            m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
            m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);
        
        }

        yield return new WaitForEndOfFrame();

        //StartCoroutine(FadeOut());
    }

    IEnumerator Fade()
    {
        m_oneloop = true;

        if(m_oneloop)
        {
            if (m_Count == 1)
            {
                m_time += Time.deltaTime;

                if (m_time > 0.5f)
                {
                    m_inStart = true;
                }

                if (!m_inStart)
                {
                    m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
                    m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
                    m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);

                    m_cloud4R.rectTransform.localPosition = new Vector3(1100f, -422, 0);
                    m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);
                }

                m_cloudL.rectTransform.localPosition += new Vector3(20, 0, 0);
                m_cloud2L.rectTransform.localPosition += new Vector3(20, 0, 0);
                m_cloud3L.rectTransform.localPosition += new Vector3(20, 0, 0);
                m_cloud4R.rectTransform.localPosition -= new Vector3(20, 0, 0);
                m_cloud5R.rectTransform.localPosition -= new Vector3(20, 0, 0);

                if (m_cloud4R.rectTransform.localPosition.x <= 196f)
                {
                    m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
                    m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);

                    if (m_cloudL.rectTransform.localPosition.x >= -336f)
                    {
                        m_cloudL.rectTransform.localPosition = new Vector3(-336f, -58, 0);
                        m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
                        m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);

                        m_Count += 1;

                    }
                }


                yield return new WaitForEndOfFrame();

            }

            if (m_Count == 2)
            {
                m_time += Time.deltaTime;


                if (m_time > 0.5f)
                {
                    m_outStart = true;
                }

                if (!m_outStart)
                {
                    m_cloudL.rectTransform.localPosition = new Vector3(-336f, -58, 0);
                    m_cloud2L.rectTransform.localPosition = new Vector3(-336f, 692, 0);
                    m_cloud3L.rectTransform.localPosition = new Vector3(-336f, -762.4f, 0);

                    m_cloud4R.rectTransform.localPosition = new Vector3(196f, -422, 0);
                    m_cloud5R.rectTransform.localPosition = new Vector3(196f, 311, 0);
                }


                m_cloudL.rectTransform.localPosition -= new Vector3(20, 0, 0);
                m_cloud2L.rectTransform.localPosition -= new Vector3(20, 0, 0);
                m_cloud3L.rectTransform.localPosition -= new Vector3(20, 0, 0);
                m_cloud4R.rectTransform.localPosition += new Vector3(20, 0, 0);
                m_cloud5R.rectTransform.localPosition += new Vector3(20, 0, 0);

                if (m_cloudL.rectTransform.localPosition.x <= -1089f)
                {
                    m_cloudL.rectTransform.localPosition = new Vector3(-1089f, -58, 0);
                    m_cloud2L.rectTransform.localPosition = new Vector3(-1089f, 692, 0);
                    m_cloud3L.rectTransform.localPosition = new Vector3(-1089f, -762.4f, 0);
                    if (m_cloud4R.rectTransform.localPosition.x >= 1100f)
                    {
                        m_cloud4R.rectTransform.localPosition = new Vector3(1100f, -422, 0);
                        m_cloud5R.rectTransform.localPosition = new Vector3(1100f, 311, 0);

                        m_Count += 1;
                    }

                }

               

                yield return new WaitForEndOfFrame();
            }
        }

        Debug.Log(m_Count);

        if(m_Count==3)
        {
            m_oneloop = false;
            m_Count = 0;
        }
      
      
    }


    // Update is called once per frame
    void Update()
    {


        StartCoroutine(FadeOut());

      
    }


  
   

}
