using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // カメラの位置を取得
        Vector3 camPos = Camera.main.transform.position;
        camPos.y = transform.position.y;
        // カメラの方向に向く
        transform.LookAt(camPos);
    }
}
