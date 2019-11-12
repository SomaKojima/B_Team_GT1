using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInfoOfHuman : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public InfoOfHuman CreateInfo(InfoOfHuman.HUMAN_TYPE type, InfoOfHuman.PLACE_TYPE _placeType)
    {
        InfoOfHuman info = new InfoOfHuman();

        info.Initialize(type, _placeType);

        return info;
    }

    static public InfoOfHuman CreateRandomInfo()
    {
        InfoOfHuman info = new InfoOfHuman();

        info.RandomSet();

        return info;
    }
}
