using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfRoutePosition : MonoBehaviour
{
    [SerializeField]
    Transform home;

    [SerializeField]
    Transform entityBuildingResource;

    [SerializeField]
    Transform road;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 Home
    {
        get { return home.position; }
    }

    public Vector3 EntityBuildingResource
    {
        get { return entityBuildingResource.position; }
    }

    public float RoadZ
    {
        get { return road.position.z; }
    }
}
