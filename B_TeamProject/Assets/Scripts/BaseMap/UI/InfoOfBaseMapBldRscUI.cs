using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoOfBaseMapBldRscUI : MonoBehaviour
{
    // 資源の種類
    InfoOfBuildingResource.BUILDING_RESOUCE_TYPE buildingRscType = InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.NONE;
    // 資源の数
    int buildingRscCount = 0;
    // テキスト
    Text uiText;

    // Update is called once per frame
    void Update()
    {
        uiText.text = buildingRscCount.ToString();
    }

    // 取得関数
    public InfoOfBuildingResource.BUILDING_RESOUCE_TYPE GetType() { return buildingRscType; }

    // 設定関数
    public void SetCount(int count) { buildingRscCount = count; }
}
