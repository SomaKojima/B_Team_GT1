using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{

    [SerializeField]
    Icon m_obj =new Icon();


    //拠点のリスト
    List<Icon> icon = new List<Icon>();

    // Start is called before the first frame update
    public void Add()
    {
        icon.Add(m_obj);
    }
}
