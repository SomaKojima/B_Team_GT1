using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOfHuman
{
    public enum HUMAN_TYPE
    {
        WOOD,

        MAX
    };

    HUMAN_TYPE type;


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
