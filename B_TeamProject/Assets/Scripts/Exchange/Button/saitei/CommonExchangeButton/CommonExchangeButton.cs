using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonExchangeButton : MonoBehaviour
{
    [SerializeField]
    FactoryOfExchangeIcon factoryIcon;

    [SerializeField]
    ManagerOfExchangeIcon managerIcon;

    [SerializeField]
    Text necessaryText;

    int necessary = 0;

    int id = 0;

    bool isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int _id, int _necessary, List<InfoOfHuman> humans, List<InfoOfBuildingResource> buildingResources)
    {
        id = _id;
        necessary = _necessary;
        necessaryText.text = necessary.ToString();

        foreach (InfoOfHuman human in humans)
        {
            managerIcon.Add(factoryIcon.Create(human.Type, 0));
        }

        foreach (InfoOfBuildingResource br in buildingResources)
        {
            managerIcon.Add(factoryIcon.Create(br.Type, br.Count));
        }
    }

    public void OnClickProcess()
    {
        isClick = false;
    }

    public void OnClick()
    {
        isClick = true;
    }

    public bool IsClick
    {
        get { return isClick; }
    }

    public int Necessary
    {
        get { return necessary; }
    }

    public int ID
    {
        get { return id; }
    }
}
