using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeButton : MonoBehaviour
{
    InfoOfHuman presentationHuman;
    InfoOfHuman necessatyHuman;

    // 提示資源のテキスト
    [SerializeField]
    Text presentationText;
    // 必要資源のテキスト
    [SerializeField]
    Text necessaryText;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initalize()
    {
        presentationText.text = presentationHuman.Type.ToString();
        necessaryText.text = necessatyHuman.Type.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {

    }

    public InfoOfHuman PresentationHuman
    {
        set { presentationHuman = value; }
    }

    public InfoOfHuman NecessatyHuman
    {
        set { necessatyHuman = value; }
    }
}
