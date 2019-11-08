using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfLogUI : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

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

    public LogUI Create(Log log)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);

        LogUI logUI = instance.GetComponent<LogUI>();
        logUI.Initialize(log.Text);

        return logUI;
    }

    public LogUI Create(string text)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);

        LogUI logUI = instance.GetComponent<LogUI>();
        logUI.Initialize(text);

        return logUI;
    }
}
