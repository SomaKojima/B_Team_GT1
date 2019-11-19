using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCommonExchange : MonoBehaviour
{
    [SerializeField]
    FactoryOfCommonExchangeButton factoryButton;

    [SerializeField]
    ManagerOfCommonExchangeButton managerButton;

    [SerializeField]
    FactoryOfCommonSelectIcon factorySelectIcon;

    [SerializeField]
    ManagerOfCommonSelectIcon managerSelectIcon;

    [SerializeField]
    SelectNecessaryWindow selectNecessaryWindow;

    // Start is called before the first frame update
    void Start()
    {
        List<InfoOfHuman> humans = new List<InfoOfHuman>();
        List<InfoOfBuildingResource> brs = new List<InfoOfBuildingResource>();


        InfoOfHuman human = CreateInfoOfHuman.CreateInfo(InfoOfHuman.HUMAN_TYPE.WOOD, InfoOfHuman.PLACE_TYPE.NONE);
        humans.Add(human);
        humans.Add(human);
        humans.Add(human);

        InfoOfBuildingResource br = CreateInfoOfBuildingResource.CreateInfo(InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MACHINE);
        br.AddCount(10);
        brs.Add(br);

        managerButton.Add(factoryButton.Create(0,10, humans, brs));


        
        // アイコンの作成
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            managerSelectIcon.Add(factorySelectIcon.Create((InfoOfHuman.HUMAN_TYPE)i));
        }
        for (int i = 0; i < (int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX; i++)
        {
            managerSelectIcon.Add(factorySelectIcon.Create((InfoOfBuildingResource.BUILDING_RESOUCE_TYPE)i));
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (CommonExchangeButton button in managerButton.GetClicks())
        {
            button.OnClickProcess();
            selectNecessaryWindow.Initialize(button.Necessary);
            selectNecessaryWindow.gameObject.SetActive(true);
        }

        int count = 0;
        foreach (CommonSelectIcon icon in managerSelectIcon.SelectIcons)
        {
            count += icon.Count;
        }
        selectNecessaryWindow.Count = count;

    }
}
