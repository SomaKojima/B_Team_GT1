using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoadBaseScene : MonoBehaviour
{
    [SerializeField]
    bool isLoad = true;

    [SerializeField]
    string scenePath = "";

    // Start is called before the first frame update
    void Start()
    {
        // 加算シーン読み込み
        string sceneName = SceneManager.GetSceneByPath(scenePath).name;
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.LoadScene(scenePath, LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}