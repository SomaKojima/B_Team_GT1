using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGame : MonoBehaviour
{
    Game game;

    [SerializeField]
    MapScene_TestManager MSTManager;

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
                game.CamerasManager.ChangeType(CameraType.CAMERA_TYPE.BASE_MAP);
            }
        }
    }
}
