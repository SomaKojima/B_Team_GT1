using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckHit : MonoBehaviour
{
    // Rayが当たったオブジェクトの情報を入れる箱
    private RaycastHit hit;
    // Rayの飛ばせる距離
    private float rayDistance = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // クリックしたとき
        if (Input.GetMouseButtonDown(0))
        {
            //　カメラからクリックした位置にレイを飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // もしRayにオブジェクトが衝突したら
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // オブジェクトの名前を取得
                string objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);
            }
        }
    }
}
