using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorInstance : MonoBehaviour
{
    const float GENERATE_HEIGHT = 30.0f;

    [SerializeField]
    GameObject prefab;
    // 基盤拠点
    [SerializeField]
    public GameObject floorBase;

    [SerializeField]
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Create()
    {
        GameObject instance = Instantiate(prefab, new Vector3(floorBase.transform.position.x, floorBase.transform.position.y + GENERATE_HEIGHT, floorBase.transform.position.z), Quaternion.identity);
        instance.transform.SetParent(parent.transform, false);

    }
}
