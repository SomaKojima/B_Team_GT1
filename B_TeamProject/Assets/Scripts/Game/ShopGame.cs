using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MonoBehaviour
{
    [SerializeField]
    Game game;

    [SerializeField]
    ExchangeUnitManager exchangeManager;

    [SerializeField]
    ExcB_Manager buttonManager;

    [SerializeField]
    ExcB_Factory buttonFactory;

    // Start is called before the first frame update
    void Start()
    {
        exchangeManager.Create();
        exchangeManager.Initialize();

        buttonManager.AddButton(buttonFactory.CreateButton(exchangeManager.Units[0]));
        // buttonManager.CreateButtons(exchangeManager.Units, exchangeManager.Units.Length);

        //button.NecessatyHuman = exchangeManager.Unit.NecessatyHuman;
        //button.PresentationHuman = exchangeManager.Unit.PresentationHuman;
        //button.Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ExchangeButton button in buttonManager.GetPressedButtons())
        {
            
        }
    }
}
