using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUnitManager : MonoBehaviour
{
    const int UNIT_MAX = 10;
    ExchangeUnit[] units = new ExchangeUnit[UNIT_MAX];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        for (int i = 0; i < UNIT_MAX; i++)
        {
            units[i] = new ExchangeUnit();
        }
    }

    public void Initialize()
    {
        for(int i = 0; i < UNIT_MAX; i++)
        {
            units[i].Initialize();
        }
    }

    public ExchangeUnit[] Units
    {
        get { return units; }
    }
}
