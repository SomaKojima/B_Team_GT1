using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene_TestManager : MonoBehaviour
{
    //拠点のリスト
    List<MapScene_Test> bases = new List<MapScene_Test>();

    [SerializeField]
    MapScene_Test[] m_obj = new MapScene_Test[(int)MapScene_Test.BaseName.Max];


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< (int)MapScene_Test.BaseName.Max;i++)
        {
            bases.Add(m_obj[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //拠点の取得
    public List<MapScene_Test> GetBases
    {
        get { return bases; }
    }
}
