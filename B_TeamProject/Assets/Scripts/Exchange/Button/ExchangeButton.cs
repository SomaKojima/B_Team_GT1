using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeButton : MonoBehaviour
{
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

    public void Initalize(string presentation, string necessaty, int _id)
    {
        presentationText.text = presentation;
        necessaryText.text = necessaty;

        isPress = false;

        id = _id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickProcess()
    {
        isPress = false;
    }

    public void OnClick()
    {
        isPress = true;
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
