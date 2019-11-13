using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectExchangePlaceGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    Shop shop;

    [SerializeField]
    Funsui funsui;

    [SerializeField]
    UIButtonClick cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shop.IsClick)
        {
            shop.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.SHOP);
        }

        if (funsui.IsClick)
        {
            funsui.OnClickProcess();
            game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.FUNSUI);
        }

        if (cancelButton.IsClick)
        {
            cancelButton.OnClickProcess();
            game.CamerasManager.Undo();
        }
    }


}
