using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Event : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    //マウスクリックフラグ
    bool m_clickFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickProcess()
    {
        m_clickFlag = false;
    }

    public void OnClick()
    {
        //クリックしたときの処理を記入（恐らくシーン遷移かと思われる）

        m_clickFlag = true;

        SceneManager.LoadScene(sceneName);
    }
}
