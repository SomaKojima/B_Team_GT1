using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCommonExchange : MonoBehaviour
{
    [SerializeField]
    FactoryOfCommonExchangeButton factoryButton;

    [SerializeField]
    ManagerOfCommonExchangeButton managerButton;

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
        br.AddCount(100);
        brs.Add(br);

        managerButton.Add(factoryButton.Create(10, humans, brs));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CommonExchangeButton button in managerButton.GetClicks())
        {

        }
    }
}
