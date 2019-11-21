using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Factory : MonoBehaviour
{
    //クリックフラグ
    bool m_isClick = false;

    //ID
    int m_id = 0;

    //交換できる残り回数
    int m_remainingNum = 0;

    //マネージャー
    IconManager m_iconManager;

    //ファクトリー
    IconFactory m_iconFactory;


    //初期化
    public void Initialize(int id,int remainingNum,List<InfoOfHuman> human,List<InfoOfBuildingResource> buildingResource)
    {

        m_id = id;
        m_remainingNum = remainingNum;


        foreach(InfoOfHuman humans in human)
        {
            
            //m_iconManager.Add(m_iconFactory.CreateHuman(humans,));
        }

    }

    //クリックした
    public void OnClick()
    {
        m_isClick = true;
    }

    //クリックし終わった
    public void OnClickProcess()
    {
        m_isClick = false;
    }

    public bool IsClick
    {
        get { return m_isClick; }
    }

    //IDの取得
    public int ID
    {

        get { return m_id; }
        set { value = m_id; }
    }


}
