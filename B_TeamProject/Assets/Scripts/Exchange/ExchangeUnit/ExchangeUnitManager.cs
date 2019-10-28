using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUnitManager : MonoBehaviour
{
    const int UNIT_MAX = 10;
    List<ExchangeUnit> units = new List<ExchangeUnit>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(ExchangeUnit unit)
    {
        units.Add(unit);
    }

    // IDからユニットを取得
    public ExchangeUnit Get(int id)
    {
        foreach (ExchangeUnit unit in units)
        {
            if (id == unit.ID)
            {
                return unit;
            }
        }
        return null;
    }

    public List<ExchangeUnit> Units
    {
        get { return units; }
    }
}
