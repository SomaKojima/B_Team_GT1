using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    MapScene_TestManager MSTManager;

    [SerializeField]
    GameObject firstSelectText;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MapScene_Test test in MSTManager.GetBases)
        {
            if (test.IsClick)
            {
                test.OnClickProcess();
                firstSelectText.SetActive(false);
                switch (test.Name)
                {
                    case MapScene_Test.BaseName.Cave:
                        game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.Cave);
                        game.Current = CameraType.CAMERA_TYPE.Cave;
                        break;
                    case MapScene_Test.BaseName.Forest:
                        game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.WOOD);
                        game.Current = CameraType.CAMERA_TYPE.WOOD;
                        break;
                }
            }
        }
    }
}
