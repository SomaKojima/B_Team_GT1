using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfoOfBuildingResource
{
    public enum BUILDING_RESOUCE_TYPE
    {
        NONE = -1,
        WOOD,

        MAX
    };

    // 人間の種別
    BUILDING_RESOUCE_TYPE type = BUILDING_RESOUCE_TYPE.NONE;

    int count = 0;

    public void Initialize(BUILDING_RESOUCE_TYPE _type)
    {
        type = _type;
    }


    // 内容をランダムで決める
    public void RandomSet()
    {
        float random = Random.Range(0.0f, (float)BUILDING_RESOUCE_TYPE.MAX - 0.01f);
        BUILDING_RESOUCE_TYPE randomType = (BUILDING_RESOUCE_TYPE)random;
        this.type = randomType;
    }


    public BUILDING_RESOUCE_TYPE Type
    {
        get { return type; }
    }

    public BUILDING_RESOUCE_TYPE ChangeToBUILDING_RESOURCE_TYPEFromHUMAN_TYPE(InfoOfHuman.HUMAN_TYPE type)
    {
        switch (type)
        {
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                return BUILDING_RESOUCE_TYPE.WOOD;
        }

        return BUILDING_RESOUCE_TYPE.NONE;
    }

    public void AddCount(int add)
    {
        count += add;
        //Debug.Log(type + "の資源量 : " + count);
    }

    public int Count
    {
        get { return count; }
    }
}
