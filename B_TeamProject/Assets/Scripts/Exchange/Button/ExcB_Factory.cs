using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcB_Factory : MonoBehaviour
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

    // ボタンの作成
    public ExchangeButton CreateButton(ExchangeUnit unit)
    {
        GameObject instance = Instantiate(prefabButton);
        instance.transform.SetParent(parent.transform, false);

        // ボタンの初期化処理
        ExchangeButton button = instance.GetComponent<ExchangeButton>();
        
        button.Initalize(unit.PresentationHuman, unit.NecessatyHuman, unit.ID);
        return button;
    }
}
