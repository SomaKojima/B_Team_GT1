using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoOfBaseMapHumanUI : MonoBehaviour
{
    // 人間の種類
    InfoOfHuman.HUMAN_TYPE humanType = InfoOfHuman.HUMAN_TYPE.NONE;
    // 人間の数
    int humanCount= 0;
    // テキスト
    Text uiText;

    // Update is called once per frame
    void Update()
    {
        uiText.text = humanCount.ToString();
    }

    // 取得関数
    public InfoOfHuman.HUMAN_TYPE GetType() {    return humanType;    }

    // 設定関数
    public void SetCount(int count)         { humanCount = count; }
}
