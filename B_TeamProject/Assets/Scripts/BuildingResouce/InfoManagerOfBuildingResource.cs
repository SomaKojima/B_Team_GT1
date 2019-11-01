using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfBuildingResource : MonoBehaviour
{
    InfoOfBuildingResource[] buildingResources = new InfoOfBuildingResource[(int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX; i++)
        {
            buildingResources[i] = CreateInfoOfBuildingResource.CreateInfo((InfoOfBuildingResource.BUILDING_RESOUCE_TYPE)i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public InfoOfBuildingResource GetBuildingResource(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE type)
    {
        return buildingResources[(int)type];
    }
}
