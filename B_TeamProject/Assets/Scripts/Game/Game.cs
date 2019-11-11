using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    InfoManagerOfHuman humanManager;

    [SerializeField]
    InfoManagerOfBuildingResource buildingManager;

    [SerializeField]
    CameraManager camerasManager;

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    LogManager logManager;

    [SerializeField]
    ManagerOfLogUI managerOfLogUI;

    [SerializeField]
    FactoryOfLogUI factoryOfLogUI;

    CameraType.CAMERA_TYPE current = CameraType.CAMERA_TYPE.WOOD;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        canvas.worldCamera = camerasManager.GetCamera();
    }

    public void CreateLogUI(string text)
    {
        managerOfLogUI.Add(factoryOfLogUI.Create(
                logManager.Add(CreateLog.Create(text))
                ));
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

    public LogManager LogManager
    {
        get { return logManager; }
    }

    public ManagerOfLogUI ManagerOfLogUI
    {
        get { return managerOfLogUI; }
    }

    public FactoryOfLogUI FactoryOfLogUI
    {
        get { return factoryOfLogUI; }
    }

    public CameraType.CAMERA_TYPE Current
    {
        get;
        set;
    }

    public InfoOfHuman.PLACE_TYPE GetHumanPlaceType()
    {
        return ChangeToHumnaPlaceTypeFromCameraType(current);
    }

    public InfoOfHuman.PLACE_TYPE ChangeToHumnaPlaceTypeFromCameraType(CameraType.CAMERA_TYPE _type)
    {
        switch (_type)
        {
            case CameraType.CAMERA_TYPE.WOOD:
                return InfoOfHuman.PLACE_TYPE.CAVE;
            case CameraType.CAMERA_TYPE.Cave:
                return InfoOfHuman.PLACE_TYPE.WOOD;
        }
        return InfoOfHuman.PLACE_TYPE.NONE;
    }
}
