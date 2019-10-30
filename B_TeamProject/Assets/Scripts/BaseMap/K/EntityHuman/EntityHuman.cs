using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHuman : MonoBehaviour
{
    
    // 人種
    InfoOfHuman.HUMAN_TYPE type = InfoOfHuman.HUMAN_TYPE.NONE;



    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="_type">人種</param>
    /// <param name="_instance">生成する実体</param>
    /// <param name="_pos">位置</param>
    /// <param name="_moveType">行動ジャンル</param>
    public void Initialize(InfoOfHuman.HUMAN_TYPE _type)
    {
        type = _type;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InfoOfHuman.HUMAN_TYPE Type
    {
        get { return type; }
    }
}
