using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfHumanObject : MonoBehaviour
{
    List<InfoOfHumanObject> humanObjects = new List<InfoOfHumanObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 人間(実体)の追加
    public void AddHumanObjects(InfoOfHumanObject info)
    {
        humanObjects.Add(info);
    }

    // 人間(実体)の削除
    public void DeleteHuman(InfoOfHumanObject info)
    {
        humanObjects.Remove(info);
    }

    // 
    public InfoOfHumanObject[] GetHumanObjects()
    {
        return humanObjects.ToArray();
    }

    /// <summary>
    /// 人種に応じて実体を取得
    /// </summary>
    /// <param name="type">人種</param>
    /// <returns>オブジェクトの実体</returns>
    public GameObject OrderInHumanType(InfoOfHuman.HUMAN_TYPE type)
    {
        GameObject obj = null;
        switch (type)
        {
            case InfoOfHuman.HUMAN_TYPE.WOOD:
                obj = (GameObject)Resources.Load("Prefabs/BaseMap/logger1");
                break;
            default:
                Debug.Log("インスタンス情報がありません");
                break;
        }

        return obj;
    }
}
