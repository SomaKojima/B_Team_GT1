using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryOfEntityHuman : MonoBehaviour
{
    [SerializeField]
    GameObject woodPrefab;
    [SerializeField]
    GameObject engineerPrefab;
    [SerializeField]
    GameObject coalMinerPrefab;

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

    public EntityHuman Create(InfoOfHuman.HUMAN_TYPE _type, Vector3 _position, Vector3 _homePosition, Vector3 _buildingResourcePosition, string tag)
    {
        switch (_type)
        {
            // 建材
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                GameObject instance = Instantiate(woodPrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = _position;

                EntityHuman human = instance.GetComponent<EntityHuman>();
                human.Initialize(_type);

                MoveOfHuman move = instance.GetComponent<MoveOfHuman>();
                move.Initialize(_homePosition, _buildingResourcePosition, tag);

                return human;
            // 機械
            case InfoOfHuman.HUMAN_TYPE.ENGINEER:
                instance = Instantiate(engineerPrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = _position;

                human = instance.GetComponent<EntityHuman>();
                human.Initialize(_type);

                move = instance.GetComponent<MoveOfHuman>();
                move.Initialize(_homePosition, _buildingResourcePosition, tag);

                return human;
            // 鉱石
            case InfoOfHuman.HUMAN_TYPE.COAL_MIEAR:
                instance = Instantiate(coalMinerPrefab);
                instance.transform.SetParent(parent.transform, false);
                instance.transform.position = _position;

                human = instance.GetComponent<EntityHuman>();
                human.Initialize(_type);

                move = instance.GetComponent<MoveOfHuman>();
                move.Initialize(_homePosition, _buildingResourcePosition, tag);

                return human;
            default:
                return null;
        }
    }
}
