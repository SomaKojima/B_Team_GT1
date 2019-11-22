using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProcessList : MonoBehaviour
{
    // 所持リストのプレハブ
    [SerializeField]
    GameObject prefab;

    // 所持リストの親オブジェクト
    [SerializeField]
    GameObject parent;

    // 所持リストを生成する位置
    [SerializeField]
    Vector3 createPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Create()
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);
        instance.transform.localPosition = createPosition;

        return instance;
    }
}
