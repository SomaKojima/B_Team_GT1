using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    CameraType.CAMERA_TYPE type = CameraType.CAMERA_TYPE.BASE_MAP;

    List<CameraType.CAMERA_TYPE> undo = new List<CameraType.CAMERA_TYPE>();

    List<Camera> cameras = new List<Camera>();
    Camera currentCumera = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.Count == 0)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                cameras.Add(obj.GetComponent<Camera>());
            }
            ChangeType(type);
        }
    }

    public void ChangeType(CameraType.CAMERA_TYPE _type)
    {
        Debug.Log("add undo");
        undo.Add(type);
        type = _type;
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

    public void Undo()
    {
        Debug.Log("undo");
        if (undo.Count == 0) return;

        type = undo[undo.Count - 1];
        undo.RemoveAt(undo.Count - 1);
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
}
