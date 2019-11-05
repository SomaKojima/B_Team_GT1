using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    List<GameObject> cameras = new List<GameObject>();

    [SerializeField]
    CameraType.CAMERA_TYPE type = CameraType.CAMERA_TYPE.BASE_MAP;

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
                cameras.Add(obj);
            }
            ChangeType(type);
        }
    }

    public void ChangeType(CameraType.CAMERA_TYPE _type)
    {
        type = _type;
        foreach (GameObject obj in cameras)
        {
            obj.SetActive(false);

            if (obj.GetComponent<CameraType>().Type == type)
            {
                obj.SetActive(true);
            }
        }
    }

    public CameraType.CAMERA_TYPE Type
    {
        get { return type; }
    }
}
