using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOfHuman
{
    public enum HUMAN_TYPE
    {
        NONE = -1,
        WOOD,

        MAX
    };

    HUMAN_TYPE type = HUMAN_TYPE.NONE;


    // 内容をランダムで決める
    void RandomSet()
    {
        HUMAN_TYPE randomType = (HUMAN_TYPE)Random.Range(0.0f, (float)HUMAN_TYPE.MAX - 0.01f);
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
