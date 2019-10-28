using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfBuildingResource : MonoBehaviour
{
    List<InfoOfBuildingResource> buildingResources = new List<InfoOfBuildingResource>();
    InfoOfBuildingResource hu = new InfoOfBuildingResource();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 人間の追加
    public void AddBuildingResources(InfoOfBuildingResource info)
    {
        buildingResources.Add(info);
    }

    public void DeleteBuildingResources(InfoOfBuildingResource info)
    {
        buildingResources.Remove(info);
    }

    // 人種別に人間を取得
    public InfoOfBuildingResource[] GetBuildingResourceOf(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE type)
    {
        List<InfoOfBuildingResource> buf = new List<InfoOfBuildingResource>();

        foreach (InfoOfBuildingResource info in buildingResources)
        {
            if (info.Type == type)
            {
                buf.Add(info);
            }
        }

        return buf.ToArray();
    }

    // 人種別にリストから消す
    public void DeleteBuildingResourceOf(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE type)
    {
        for (int i = buildingResources.Count - 1; i >= 0; i--)
        {
            if (buildingResources[i].Type == type)
            {
                buildingResources.RemoveAt(i);
            }
        }
    }

    public List<InfoOfBuildingResource> BuildingResources
    {
        get { return buildingResources; }
    }


    public InfoOfBuildingResource HU
    {
        get { return hu; }
    }
}
