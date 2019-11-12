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
        foreach (LogUI logUI in logUIs)
        {
            logUI.gameObject.SetActive(logUI.IsVisible);
        }
    }

    void Clear()
    {
        foreach (LogUI logUI in logUIs)
        {
            logUI.IsVisible = false;
        }
    }

    public void ActiveLogUI(int index, string text)
    {
        if (logUIs.Count == 0) return;
        if (index >= logUIs.Count || index < 0) return;

        LogUI logUI = logUIs[index];
        logUI.IsVisible = true;
        logUI.Text = text;
    }

    public LogUI Add(LogUI logUI)
    {
        logUIs.Add(logUI);
        return logUI;
    }

    public int MaxLog
    {
        get { return logUIs.Count; }
    }

    public List<LogUI> LogUIs
    {
        get { return logUIs; }
    }
}
