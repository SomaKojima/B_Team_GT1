using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcB_Manager : MonoBehaviour
{
    List<ExchangeButton> buttonList = new List<ExchangeButton>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 押されたボタンを取得
    public List<ExchangeButton> GetPressedButtons()
    {
        List<ExchangeButton> buf = new List<ExchangeButton>();
        foreach (ExchangeButton button in buttonList)
        {
            if (button.IsPress)
            {
                buf.Add(button);
            }
        }

        return buf;
    }

    // ボタンの追加
    public void AddButton(ExchangeButton button)
    {
        buttonList.Add(button);
    }
}
