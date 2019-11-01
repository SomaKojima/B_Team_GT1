using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInfoOfBuildingResource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public InfoOfBuildingResource CreateInfo(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE _type)
    {
        InfoOfBuildingResource info = new InfoOfBuildingResource();
        info.Initialize(_type);
        return info;
    }

    static public InfoOfBuildingResource CreateRandomInfo()
    {
        InfoOfBuildingResource info = new InfoOfBuildingResource();
        info.RandomSet();
        return info;
    }
}
