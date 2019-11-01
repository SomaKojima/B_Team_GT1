using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public enum Scene
    {
        SCENE_NONE,

        SCENE_TITLE,
        SCENE_LOBBY,
        SCENE_DICE,
        SCENE_MAP,
        SCENE_BASE,
        SCENE_MARKET
    }

    // シーン情報
    [SerializeField]
    private Scene sceneState = Scene.SCENE_NONE;
    // シーンをまとめているオブジェクト
    //[SerializeField]
    //private GameObject sceneMasterObj = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 次のシーンを決める
    /// </summary>
    public void ChangeScene(Scene nextScene)
    {
        switch(nextScene)
        {
            // シーン情報がわからない
            case Scene.SCENE_NONE:
            default:
                Debug.Log("シーン情報が不明です");
                break;
                
            // シーン情報を更新
            case Scene.SCENE_TITLE:
            case Scene.SCENE_LOBBY:
            case Scene.SCENE_DICE:
            case Scene.SCENE_MAP:
            case Scene.SCENE_BASE:
            case Scene.SCENE_MARKET:
                sceneState = nextScene;
                break;
        }
    }
}
