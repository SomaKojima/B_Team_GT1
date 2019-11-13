using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    CameraType.CAMERA_TYPE type = CameraType.CAMERA_TYPE.BASE_MAP;

    List<CameraType.CAMERA_TYPE> undo = new List<CameraType.CAMERA_TYPE>();
    bool isChange = false;
    bool isUndo = false;

    List<Camera> cameras = new List<Camera>();
    Camera currentCumera = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (cameras.Count == 0)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                cameras.Add(obj.GetComponent<Camera>());
            }
            ChangeType(type);
            OnChangeTypeProcess();
        }
    }

    public void OnChangeTypeProcess()
    {
        isChange = false;

        if (isUndo)
        {
            isUndo = false;
            if (undo.Count == 0) return;

            type = undo[undo.Count - 1];
            undo.RemoveAt(undo.Count - 1);
        }

        foreach (Camera obj in cameras)
        {
            obj.gameObject.SetActive(false);

            if (obj.GetComponent<CameraType>().Type == type)
            {
                currentCumera = obj;
                obj.gameObject.SetActive(true);
            }
        }
    }

    public void ChangeType(CameraType.CAMERA_TYPE _type)
    {
        isChange = true;
        undo.Add(type);
        type = _type;
    }

    public void Undo()
    {
        isChange = true;
        isUndo = true;
    }

    public CameraType.CAMERA_TYPE BeforeType()
    {
        return undo[undo.Count - 1];
    }

    public Camera GetCamera()
    {
        return currentCumera;
    }

    public CameraType.CAMERA_TYPE Type
    {
        get { return type; }
    }

    public bool IsChange
    {
        get { return isChange; }
    }
}
