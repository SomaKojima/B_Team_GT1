using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraType : MonoBehaviour
{
    public enum CAMERA_TYPE
    {
        BASE_MAP,
        MAP,
        SHOP,
        FUNSUI
    }

    [SerializeField]
    CAMERA_TYPE type = CAMERA_TYPE.BASE_MAP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CAMERA_TYPE Type
    {
        get { return type; }
    }
}
