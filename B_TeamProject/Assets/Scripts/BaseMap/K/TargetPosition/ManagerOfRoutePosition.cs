using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfRoutePosition : MonoBehaviour
{
    Transform home = null;

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

    public Transform Home
    {
        get { return home; }
        set { home = value; }
    }

    public Transform EntityBuildingResource
    {
        get { return entityBuildingResource; }
    }

    public float RoadZ
    {
        get { return road.position.z; }
    }
}
