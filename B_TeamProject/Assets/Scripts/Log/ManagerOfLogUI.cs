using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfLogUI : MonoBehaviour
{
    List<LogUI> logUIs = new List<LogUI>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LogUI Add(LogUI logUI)
    {
        logUIs.Add(logUI);
        return logUI;
    }

    public List<LogUI> LogUIs
    {
        get { return logUIs; }
    }
}
