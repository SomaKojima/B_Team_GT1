using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryOfCommonSelectIcon : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    Sprite human_wood;
    [SerializeField]
    Sprite human_enginer;
    [SerializeField]
    Sprite human_coal_miear;

    [SerializeField]
    Sprite br_machine;

    [SerializeField]
    Sprite br_ore;

    [SerializeField]
    Sprite br_wood;

    [SerializeField]
    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public CommonSelectIcon Create(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE _type)
    {
        GameObject instance = null;
        instance = Instantiate(prefab);
        
        instance.transform.SetParent(parent.transform, false);

        CommonSelectIcon icon = instance.GetComponent<CommonSelectIcon>();
        icon.Initialize(CreateSprite(_type), _type, InfoOfHuman.HUMAN_TYPE.NONE);

        return icon;
    }

    public CommonSelectIcon Create(InfoOfHuman.HUMAN_TYPE _type)
    {
        GameObject instance = null;
        instance = Instantiate(prefab);

        instance.transform.SetParent(parent.transform, false);

        CommonSelectIcon icon = instance.GetComponent<CommonSelectIcon>();
        icon.Initialize(CreateSprite(_type), InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.NONE, _type);

        return icon;
    }

    // 人間の種別に、アイコンのプレハブを作成
    Sprite CreateSprite(InfoOfHuman.HUMAN_TYPE _type)
    {
        switch (_type)
        {
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                return human_wood;
            case InfoOfHuman.HUMAN_TYPE.ENGINEER:
                return human_enginer;
            case InfoOfHuman.HUMAN_TYPE.COAL_MIEAR:
                return human_coal_miear;
        }

        return null;
    }

    // 人間の種別に、アイコンのプレハブを作成
    Sprite CreateSprite(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE _type)
    {
        switch (_type)
        {
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MACHINE:
                return br_machine;
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.ORE:
                return br_ore;
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD:
                return br_wood;
        }

        return null;
    }
}
