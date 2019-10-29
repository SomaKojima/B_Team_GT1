using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInfoOfHumanObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// オブジェクトを初期化したものを返す
    /// </summary>
    /// <param name="type">人種</param>
    /// <param name="instance">実体</param>
    /// <param name="pos">位置</param>
    /// <param name="moveType">行動ジャンル</param>
    /// <returns>オブジェクト情報</returns>
    static public InfoOfHumanObject CreateInfo(InfoOfHuman.HUMAN_TYPE type, GameObject instance, Vector3 pos, InfoOfHumanObject.HUMAN_MOVE moveType)
    {
        InfoOfHumanObject humanObj = new InfoOfHumanObject();
        humanObj.Initialize(type, instance, pos, moveType);

        return humanObj;
    }

    /// <summary>
    /// オブジェクトをランダムに初期化したものを返す
    /// </summary>
    /// <returns>オブジェクト情報</returns>
    static public InfoOfHumanObject CreateRandomInfo()
    {
        InfoOfHumanObject info = new InfoOfHumanObject();

        info.RandomSet();

        return info;
    }
}
