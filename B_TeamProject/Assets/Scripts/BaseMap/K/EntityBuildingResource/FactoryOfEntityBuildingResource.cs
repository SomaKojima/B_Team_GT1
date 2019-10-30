﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfEntityBuildingResource : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

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
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);
        instance.transform.position = position;

        EntityBuildingResource br = instance.GetComponent<EntityBuildingResource>();
        br.Initialize(_type);

        return br;
    }
}
