using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorInstance : MonoBehaviour
{
    const float GENERATE_HEIGHT = 10.0f;

    [SerializeField]
    GameObject floorPrefab;

    [SerializeField]
    GameObject floorBasePrefab;

    // 基盤拠点
    [SerializeField]
    public Transform createPosition;

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


    public Floor CreateFloor(Transform position)
    {
        GameObject instance = Instantiate(floorPrefab, new Vector3(position.localPosition.x, position.localPosition.y + GENERATE_HEIGHT, position.localPosition.z), Quaternion.identity);
        instance.transform.SetParent(parent.transform, false);

        Floor floor = instance.GetComponent<Floor>();

        return floor;
    }

    public Floor CreateFloorBase()
    {
        GameObject instance = Instantiate(floorBasePrefab, new Vector3(createPosition.localPosition.x, createPosition.localPosition.y + GENERATE_HEIGHT, createPosition.localPosition.z), Quaternion.identity);
        instance.transform.SetParent(parent.transform, false);

        Floor floor = instance.GetComponent<Floor>();

        return floor;
    }
}
