using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOfHuman
{
    /// <summary>
    /// 人間の種別
    /// </summary>
    public enum HUMAN_TYPE
    {
        NONE = -1,
        WOOD,
        ENGINEER,
        COAL_MIEAR,

        MAX
    };

    // 人間の種別
    HUMAN_TYPE type = HUMAN_TYPE.NONE;

    public void Initialize(HUMAN_TYPE _type)
    {
        type = _type;
    }


    // 内容をランダムで決める
    public void RandomSet()
    {
        float random = Random.Range(0.0f, (float)HUMAN_TYPE.MAX - 0.01f);
        HUMAN_TYPE randomType = (HUMAN_TYPE)random;
        this.type = randomType;
    }


    public HUMAN_TYPE Type
    {
        get { return type; }
    }
}


//public class InfoOfHuman : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
