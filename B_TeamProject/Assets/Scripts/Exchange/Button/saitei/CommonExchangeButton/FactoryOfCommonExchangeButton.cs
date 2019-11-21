using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfCommonExchangeButton : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

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


    public CommonExchangeButton Create(int id, int necessary, List<InfoOfHuman> humans, List<InfoOfBuildingResource> buildingResources)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);

        CommonExchangeButton button = instance.GetComponent<CommonExchangeButton>();
        button.Initialize(id, necessary, humans, buildingResources);

        return button;
    }
}
