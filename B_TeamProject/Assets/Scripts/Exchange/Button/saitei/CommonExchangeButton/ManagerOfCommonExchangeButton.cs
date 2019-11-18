using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfCommonExchangeButton : MonoBehaviour
{
    List<CommonExchangeButton> buttons = new List<CommonExchangeButton>();
    List<CommonExchangeButton> clicks = new List<CommonExchangeButton>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clicks.Clear();
        foreach (CommonExchangeButton button in buttons)
        {
            if (button.IsClick)
            {
                clicks.Add(button);
            }
        }
    }

    public void Add(CommonExchangeButton _button)
    {
        buttons.Add(_button);
    }

    public List<CommonExchangeButton> GetClicks()
    {
        return clicks;
    }
}
