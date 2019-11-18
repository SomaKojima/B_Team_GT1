using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryOfCommonSelectIcon : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public CommonSelectIcon Create()
    {
        GameObject instance = null;
        instance = Instantiate(prefab);
        
        instance.transform.SetParent(parent.transform, false);

        CommonSelectIcon icon = instance.GetComponent<CommonSelectIcon>();

        return icon;
    }
}
