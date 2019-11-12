using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    readonly int MAX_SIZE = 100;
    List<Log> logs = new List<Log>();
    int endCount = 0;
    bool isAddLogs = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isAddLogs = false;
        if (endCount != logs.Count)
        {
            isAddLogs = true;
        }
        endCount = logs.Count;

        while (logs.Count > MAX_SIZE)
        {
            logs.RemoveAt(0);
        }
    }

    public Log Add(Log log)
    {
        logs.Add(log);
        return log;
    }

    public List<Log> Logs
    {
        get { return logs; }
    }

    public bool IsAddLogs
    {
        get{ return isAddLogs; }
    }
}
