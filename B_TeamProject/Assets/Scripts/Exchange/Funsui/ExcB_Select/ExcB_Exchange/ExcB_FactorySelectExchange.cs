using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcB_FactorySelectExchange : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ExcB_SelectExchange Create(string _name, int _id)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);

        // ボタンの初期化処理
        ExcB_SelectExchange button = instance.GetComponent<ExcB_SelectExchange>();

        button.Initialize(_name, _id);

        return button;
    }
}
