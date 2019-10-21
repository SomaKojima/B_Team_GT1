using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorInstance : MonoBehaviour
{
    // 基盤拠点
    [SerializeField]
    public GameObject floorBase;

    // 階層のストック
    [SerializeField]
    private int floorStock = 5;

    // Start is called before the first frame update
    void Start()
    {
        // 基盤拠点のサイズ、位置取得
        float baseWidth = floorBase.GetComponent<SpriteRenderer>().bounds.size.x;
        float baseHeight = floorBase.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector3 basePos = floorBase.GetComponent<Transform>().position;

        // FloorInstanceプレハブをGameObject型で取得
        GameObject floorInstance = (GameObject)Resources.Load("floor_instance");
        // FloorInstanceプレハブのサイズ取得
        float floorWidth = floorInstance.GetComponent<SpriteRenderer>().bounds.size.x;
        float floorHeight = floorInstance.GetComponent<SpriteRenderer>().bounds.size.y;

        // ストック分の階層を建てる
        for (int i = 0; i < floorStock; i++)
        {
            // 一階は既に建ててあるのでスキップ
            if (i == 0) continue;

            // 基盤拠点の上辺を取得
            float basePosTop = basePos.y + (baseHeight*0.5f);

            // FloorInstanceプレハブを元に、インスタンスを生成
            // ストック分増設
            Instantiate(floorInstance, new Vector3(basePos.x, basePosTop+((i* floorHeight) - (floorHeight*0.5f)), basePos.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
