using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcB_ManagerOfSelectPlayer : MonoBehaviour
{
    List<ExcB_SelectPlayer> buttons = new List<ExcB_SelectPlayer>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 押されたボタンを取得
    public List<ExcB_SelectPlayer> GetClickButtons()
    {
        List<ExcB_SelectPlayer> buf = new List<ExcB_SelectPlayer>();
        foreach (ExcB_SelectPlayer button in buttons)
        {
            if (button.IsClick)
            {
                buf.Add(button);
            }
        }

        return buf;
    }

    public void Add(ExcB_SelectPlayer _button)
    {
        buttons.Add(_button);
    }
    
    public List<ExcB_SelectPlayer> Buttons
    {
        get { return buttons; }
    }
}
