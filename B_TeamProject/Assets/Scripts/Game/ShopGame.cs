using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    [SerializeField]
    Game game;

    [SerializeField]
    ExchangeButton button;

    // Start is called before the first frame update
    void Start()
    {
        button.NecessatyHuman = game.HumanManager.HU;
        button.PresentationHuman = game.HumanManager.HU;
        button.Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
