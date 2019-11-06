using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Log Create(string text)
    {
        Log log = new Log();

        log.Initialize(text);

        return log;
    }
}
