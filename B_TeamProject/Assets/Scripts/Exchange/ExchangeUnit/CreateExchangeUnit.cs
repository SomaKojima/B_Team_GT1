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
    
    static public ExchangeUnit Create(List<InfoOfHuman> presHumans, List<InfoOfBuildingResource> presBRs, int neccesaryCount)
    {
        ExchangeUnit unit = new ExchangeUnit();

        unit.Initialize(presHumans, presBRs, null, null, neccesaryCount);

        return unit;
    }

    static public ExchangeUnit Create(List<InfoOfHuman> presHumans, List<InfoOfBuildingResource> presBRs, List<InfoOfHuman> neceHumans, List<InfoOfBuildingResource> neceBRs)
    {
        ExchangeUnit unit = new ExchangeUnit();

        unit.Initialize(presHumans, presBRs, neceHumans, neceBRs);

        return unit;
    }
}
