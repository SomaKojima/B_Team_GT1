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
                break;
        }

        return BUILDING_RESOUCE_TYPE.NONE;
    }
}
