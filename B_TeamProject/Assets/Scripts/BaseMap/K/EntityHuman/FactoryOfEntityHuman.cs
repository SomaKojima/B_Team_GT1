using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfEntityHuman : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EntityHuman Create(InfoOfHuman.HUMAN_TYPE _type, Vector3 position)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.SetParent(parent.transform, false);
        instance.transform.position = position;

        EntityHuman human = instance.GetComponent<EntityHuman>();
        human.Initialize(_type);

        return human;
    }
}
