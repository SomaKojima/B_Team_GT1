using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene_Test : MonoBehaviour
{

    //拠点の種類
    public enum BaseName
    {
        Forest,
        Factory,
        Farm,
        Cave,
        Workshop,
        Fuel,

        Max
    };

    [SerializeField]
    BaseName m_name;

    //マウスクリックフラグ
    bool m_clickFlag;


    // Start is called before the first frame update
    void Start()
    {
        m_clickFlag = false;
    }

    // Update is called once per frame

     //クリックし終わった
    public void OnClickProcess()
    {
        m_clickFlag = false;
    }

    //クリックした
    public void OnClick()
    {
        Debug.Log(m_name.ToString());

        m_clickFlag = true;
    }

    //拠点の名前を取得
    public BaseName Name
    {
        get { return m_name; }
    }

    public bool IsClick
    {
        get { return m_clickFlag; }
    }
}
