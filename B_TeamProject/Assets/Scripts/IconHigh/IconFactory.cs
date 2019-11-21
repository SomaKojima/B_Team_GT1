using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconFactory : MonoBehaviour
{
    [SerializeField]
    GameObject preb = null;


    //Icon m_icon;

    [SerializeField]
    Sprite wood;

    [SerializeField]
    Sprite crystal;

    [SerializeField]
    Sprite woodCutter;

    [SerializeField]
    Sprite engineer;

    [SerializeField]
    Sprite coalMiear;


    public void HumanInstance()
    {
        GameObject instance = Instantiate(preb);
        instance.transform.SetParent(this.transform,false);

        Icon icon= instance.gameObject.GetComponent<Icon>();


        icon.Init(0, crystal);


    }

    public void BuildingInstance()
    {
        GameObject instance = Instantiate(preb);
        instance.transform.SetParent(this.transform, false);

        Icon icon = instance.gameObject.GetComponent<Icon>();


        icon.Init(0, wood);
    }


    public Sprite CreateHuman(InfoOfHuman human,Sprite sp)
    {
        switch (human.Type)
        {
            case InfoOfHuman.HUMAN_TYPE.NONE:
                break;
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                return sp=woodCutter;
            case InfoOfHuman.HUMAN_TYPE.ENGINEER:
                return sp=engineer;
            case InfoOfHuman.HUMAN_TYPE.COAL_MIEAR:
                return sp=coalMiear;

        }

        return sp;

    }

    public Sprite CreateBuildingresources(InfoOfBuildingResource build,Sprite sp)
    {
        switch (build.Type)
        {
            case InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.WOOD:
                return sp = wood;

        }

        return sp;
    }

}
