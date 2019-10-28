using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeButton : MonoBehaviour
{
    InfoOfHuman presentationHuman = new InfoOfHuman();
    InfoOfHuman necessatyHuman = new InfoOfHuman();
    bool isPress = false;

    // 提示資源のテキスト
    [SerializeField]
    Text presentationText;
    // 必要資源のテキスト
    [SerializeField]
    Text necessaryText;

    // どの交換ユニットとつながっているか
    int id = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Initalize(InfoOfHuman presentation, InfoOfHuman necessaty, int _id)
    {
        presentationHuman = presentation;
        necessatyHuman = necessaty;
        presentationText.text = presentationHuman.Type.ToString();
        necessaryText.text = necessatyHuman.Type.ToString();

        isPress = false;

        id = _id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        isPress = true;
    }

    public InfoOfHuman PresentationHuman
    {
        set { presentationHuman = value; }
    }

    public InfoOfHuman NecessatyHuman
    {
        set { necessatyHuman = value; }
    }

    public bool IsPress
    {
        get { return isPress; }
    }

    public int ID
    {
        get { return id; }
    }
}
