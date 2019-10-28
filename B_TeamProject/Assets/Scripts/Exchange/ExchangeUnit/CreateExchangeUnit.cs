using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExchangeUnit
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    static public ExchangeUnit Create()
    {
        ExchangeUnit unit = new ExchangeUnit();
        unit.RandomSet();

        return unit;
    }
}
