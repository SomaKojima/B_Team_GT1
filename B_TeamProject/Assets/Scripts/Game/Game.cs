using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    InfoManagerOfHuman humanManager;

    [SerializeField]
    InfoManagerOfBuildingResource buildingManager;

    [SerializeField]
    CameraManager camerasManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public InfoManagerOfHuman HumanManager
    {
        get { return humanManager; }
    }

    public InfoManagerOfBuildingResource BuildingManager
    {
        get { return buildingManager; }
    }

    public CameraManager CamerasManager
    {
        get { return camerasManager; }
    }
}
