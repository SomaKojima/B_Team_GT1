using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBuildingResource : MonoBehaviour
{
    const int COUNT = 1;

    [SerializeField]
    Transform collectPos;

    InfoOfBuildingResource.BUILDING_RESOUCE_TYPE type = InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE _type)
    {
        type = _type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetBuildingResourceCount()
    {
        return COUNT;
    }

    public InfoOfBuildingResource.BUILDING_RESOUCE_TYPE Type
    {
        get { return type; }
    }

    public Vector3 CollectPos
    {
        get { return collectPos.position; }
    }
}
