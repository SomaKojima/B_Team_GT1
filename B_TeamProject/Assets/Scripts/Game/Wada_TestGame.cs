using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wada_TestGame : MonoBehaviour
{
    [SerializeField]
    Message message;

    [SerializeField]
    LogManager logManager;

    [SerializeField]
    ManagerOfLogUI managerOfLogUI;

    [SerializeField]
    FactoryOfLogUI factoryOfLogUI;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            managerOfLogUI.Add(factoryOfLogUI.Create(
                logManager.Add(CreateLog.Create("資源を得た x" + count.ToString()))
                ));
            count += 1;
        }
    }
}
