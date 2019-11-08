using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    List<Log> logs = new List<Log>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
