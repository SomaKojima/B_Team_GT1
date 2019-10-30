using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloorInstance : MonoBehaviour
{
    const float GENERATE_HEIGHT = 30.0f;
    // 基盤拠点
    [SerializeField]
    public GameObject floorBase;

    // 階層のストック
    [SerializeField]
    private int floorStock = 5;

    // Start is called before the first frame update
    void Start()
    {
        // FloorInstanceプレハブをGameObject型で取得
        GameObject floorInstance = (GameObject)Resources.Load("Prefabs/BaseMap/FloorInstance");

        // ストック分の階層を建てる
        for (int i = 0; i < floorStock; i++)
        {
            // 一階は既に建ててあるのでスキップ
            if (i == 0) continue;

            // FloorInstanceプレハブを元に、インスタンスを生成
            // ストック分増設
            Instantiate(floorInstance, new Vector3(floorBase.transform.position.x, floorBase.transform.position.y + GENERATE_HEIGHT, floorBase.transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
