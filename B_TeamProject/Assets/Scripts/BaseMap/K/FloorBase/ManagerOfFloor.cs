using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfFloor : MonoBehaviour
{
    List<Floor> floors = new List<Floor>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(Floor _floor)
    {
        floors.Add(_floor);
    }

    public Floor GetBaseFloor()
    {
        return floors[0];
    }

    public List<Floor> Floors
    {
        get { return floors; }
    }

    public Floor GetTopFloor()
    {
        if (floors.Count <= 0) return null;
        return floors[floors.Count - 1];
    }

    public Floor GetTopTwoFloor()
    {
        if (floors.Count <= 0) return null;
        if (floors.Count - 2 <= 0)
        {
            return GetTopFloor();
        }
        return floors[floors.Count - 2];
    }
}
