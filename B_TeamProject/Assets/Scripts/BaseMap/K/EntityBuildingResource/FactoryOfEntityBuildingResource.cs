using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfEntityBuildingResource : MonoBehaviour
{
    [SerializeField]
    GameObject woodPrefab;
    [SerializeField]
    GameObject machinePrefab;
    [SerializeField]
    GameObject orePrefab;

    [SerializeField]
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EntityBuildingResource Create(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE _type, Vector3 position)
    {
        switch(_type)
        {
            // 建材
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD:
                GameObject instance = Instantiate(woodPrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = position;

                EntityBuildingResource br = instance.GetComponent<EntityBuildingResource>();
                br.Initialize(_type);
                return br;
            // 機械
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MACHINE:
                instance = Instantiate(machinePrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = position;

                br = instance.GetComponent<EntityBuildingResource>();
                br.Initialize(_type);
                return br;
            // 鉱石
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.ORE:
                instance = Instantiate(orePrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = position;

                br = instance.GetComponent<EntityBuildingResource>();
                br.Initialize(_type);
                return br;
            default:
                return null;
        }
    }
}
