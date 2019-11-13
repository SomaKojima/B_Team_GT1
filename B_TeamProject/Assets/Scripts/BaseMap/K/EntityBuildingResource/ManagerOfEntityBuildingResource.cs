using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfEntityBuildingResource : MonoBehaviour
{
    List<EntityBuildingResource> entityBRs = new List<EntityBuildingResource>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EntityBuildingResource obj in entityBRs)
        {

        }
    }

    public void Add(EntityBuildingResource entity)
    {
        entityBRs.Add(entity);
    }

    public List<EntityBuildingResource> EntityBRs
    {
        get { return entityBRs; }
    }

    public Vector3 FirstPosition
    {
        get { return EntityBRs[0].gameObject.transform.position; }
    }
}
