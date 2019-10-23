using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneManager : MonoBehaviour
{
    GameObject player;
    InfoManagerOfHuman infoManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Debug.Log(player);
        //infoManager = player.transform.GetChild(0).GetComponent<InfoManagerOfHuman>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        Debug.Log(player);
    }
}
