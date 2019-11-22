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

    [SerializeField]
    CloudMove2 cloud;

    [SerializeField]
    PVManager pvManager;

    CameraType.CAMERA_TYPE current = CameraType.CAMERA_TYPE.WOOD;


    // Start is called before the first frame update
    void Start()
    {
        cloud.Initialize();

        for (int i = 0; i < 20; i++)
        {
            managerOfLogUI.Add(factoryOfLogUI.Create(""));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (camerasManager.IsChange)
        {
            //camerasManager.OnChangeTypeProcess();
            StartCoroutine(cloud.FadeIn());
            if (!cloud.IsProcess)
            {
                camerasManager.OnChangeTypeProcess();
            }
        }
        else
        {
            StartCoroutine(cloud.FadeOut());
        }
        canvas.worldCamera = camerasManager.GetCamera();

        if (logManager.IsAddLogs)
        {
            UpdateLogUI();
        }
        
    }

    private void UpdateLogUI()
    {
        // ログを検索するオフセットを計算
        int logIndexOffset = logManager.Logs.Count - managerOfLogUI.MaxLog;

        // UIの数より少ない場合はオフセットはゼロから
        if (logIndexOffset < 0) logIndexOffset = 0;
        for (int i = 0; i < managerOfLogUI.MaxLog; i++)
        {
            // ログの最大数を超えた場合は処理を抜ける
            if (i >= logManager.Logs.Count) { break; }

            // ログからログUIを作る
            managerOfLogUI.ActiveLogUI(i, logManager.Logs[logIndexOffset + i].Text);
        }
    }

    public void CreateLogUI(string text)
    {
        logManager.Add(CreateLog.Create(text));
        //managerOfLogUI.Add(factoryOfLogUI.Create(
        //        logManager.Add(CreateLog.Create(text))
        //        ));
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
        get { return current; }
        set { current = value; }
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
                return InfoOfHuman.PLACE_TYPE.WOOD;
            case CameraType.CAMERA_TYPE.Cave:
                return InfoOfHuman.PLACE_TYPE.CAVE;
        }
        return InfoOfHuman.PLACE_TYPE.NONE;
    }

    public PVManager PvManager
    {
        get { return pvManager; }
    }
}
