using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcB_FactorySelectPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject prefabButton;

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

    public ExcB_SelectPlayer Create(string text, int id)
    {
        GameObject instance = Instantiate(prefabButton);
        instance.transform.SetParent(parent.transform, false);

        // ボタンの初期化処理
        ExcB_SelectPlayer button = instance.GetComponent<ExcB_SelectPlayer>();

        button.Initialize(text, id);

        return button;
    }

}
