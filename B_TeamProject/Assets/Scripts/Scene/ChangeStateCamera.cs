using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateCamera : MonoBehaviour
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
    /// カメラのアクティブ情報を切り替え
    /// </summary>
    /// <param name="nextCameraParent">カメラの親オブジェクト</param>
    /// <param name="nextCamera">次にアクティブにするカメラ</param>
    public void Change(string nextCameraParent, string nextCamera)
    {
        // 現在アクティブなカメラを非アクティブに
        // 非アクティブなカメラをアクティブに
        GameObject.Find(nextCameraParent).transform.Find(nextCamera).gameObject.SetActive(
                !GameObject.Find(nextCameraParent).transform.Find(nextCamera).gameObject.activeSelf);
    }
}
