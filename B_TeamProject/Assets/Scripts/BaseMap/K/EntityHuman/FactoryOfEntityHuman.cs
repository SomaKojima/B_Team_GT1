using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfEntityHuman : MonoBehaviour
{
    [SerializeField]
    GameObject woodPefab;

    [SerializeField]
    GameObject coalMiearPrefab;

    [SerializeField]
    GameObject enginerPrefab;

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

    public EntityHuman Create(InfoOfHuman.HUMAN_TYPE _type, Vector3 _position, string tag)
    {
        GameObject instance = null;

        switch (_type)
        {
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                instance = Instantiate(woodPefab);
                break;
            case InfoOfHuman.HUMAN_TYPE.COAL_MIEAR:
                instance = Instantiate(coalMiearPrefab);
                break;
            case InfoOfHuman.HUMAN_TYPE.ENGINEER:
                instance = Instantiate(enginerPrefab);
                break;
        }

        if (instance == null) return null;
        instance.transform.SetParent(parent.transform, false);
        instance.transform.position = _position;

        EntityHuman human = instance.GetComponent<EntityHuman>();
        human.Initialize(_type);

        MoveOfHuman move = instance.GetComponent<MoveOfHuman>();
        move.Initialize(tag);

        return human;
    }
}
