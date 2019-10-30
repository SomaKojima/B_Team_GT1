using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfEntityHuman : MonoBehaviour
{
    List<EntityHuman> humans = new List<EntityHuman>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(EntityHuman human)
    {
        humans.Add(human);
    }

    public List<EntityHuman> Humans
    {
        get { return humans; }
    }
}
