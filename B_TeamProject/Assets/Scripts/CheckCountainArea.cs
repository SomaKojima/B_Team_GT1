using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCountainArea : MonoBehaviour
{
    // 調べる範囲
    [SerializeField]
    Rect rect;

    // カメラ内を調べる場合のカメラ
    [SerializeField]
    Camera camera;

    [SerializeField]
    Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// エリア内に調べる位置があったらtrueを返す
    /// </summary>
    /// <param name="checkPos">調べる位置</param>
    /// <param name="width">幅</param>
    /// <param name="height">高さ</param>
    /// <returns></returns>
    public bool IsCountainArea(Vector3 checkPos, float width, float height)
    {
        return rect.Contains(checkPos);
    }

    /// <summary>
    /// カメラ内に調べる位置があったらtrueを返す
    /// </summary>
    /// <param name="checkPos">調べる位置</param>
    /// <param name="width">幅</param>
    /// <param name="height">高さ</param>
    /// <returns></returns>
    public bool IsCountainCameraArea(Vector3 checkPos, float width, float height)
    {
        return rect.Contains(camera.WorldToViewportPoint(checkPos));
    }

    /// <summary>
    /// カメラ内に調べる位置があったらtrueを返す
    /// </summary>
    /// <param name="checkPos">調べる位置</param>
    /// <param name="width">幅</param>
    /// <param name="height">高さ</param>
    /// <returns></returns>
    public bool IsCountainCanvasArea(Vector3 checkPos, float width, float height)
    {
        Debug.Log("rect:"+ canvas.pixelRect);
        Debug.Log("pos:" + checkPos);
        Debug.Log("bool:" + rect.Contains(checkPos));
        
        return rect.Contains(checkPos);
    }
}
