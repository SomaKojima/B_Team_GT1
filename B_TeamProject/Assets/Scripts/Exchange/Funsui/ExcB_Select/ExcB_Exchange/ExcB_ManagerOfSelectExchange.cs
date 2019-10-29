using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcB_ManagerOfSelectExchange : MonoBehaviour
{
    List<ExcB_SelectExchange> buttons = new List<ExcB_SelectExchange>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(ExcB_SelectExchange button in buttons)
        {
            if (button.IsDownPointer)
            {
                button.OnClickProcess();
            }
        }
    }

    public void Add(ExcB_SelectExchange _button)
    {
        buttons.Add(_button);
    }

    public List<ExcB_SelectExchange> Buttons
    {
        get { return buttons; }
    }
}
