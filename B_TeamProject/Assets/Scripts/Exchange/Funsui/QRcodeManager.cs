using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QRcodeManager : MonoBehaviour
{
    // QRコードを生成する文字列
    private string createQRStrList = "null";

    // QR表示オブジェクト
    [SerializeField]
    RawImage qrImage = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 文字列をQRコードテクスチャにする
    /// Texture型で返す
    /// </summary>
    /// <param name="str">QRコードを生成する文字列</param>
    /// <returns>QRコードテクスチャ</returns>
    public Texture CreateQRcode(string str)
    {
        // 指定文字列からQRテクスチャ生成
        return QRCodeHelper.CreateQRCode(str, 256, 256);
    }

    /// <summary>
    /// QRコードの状態を設定
    /// </summary>
    /// <param name="flag">ture=アクティブ、false=非アクティブ</param>
    public void SetActiveQRcode(bool flag)
    {
        if (flag)
            qrImage.enabled = true;
        else
            qrImage.enabled = false;
    }

    /// <summary>
    /// QRコード生成文字列の取得、設定
    /// </summary>
    public string CreateQRStrList
    {
        get { return createQRStrList; }
        set { createQRStrList = value; }
    }

    /// <summary>
    /// QRコードの取得、設定
    /// </summary>
    public Texture QRImage
    {
        get { return qrImage.texture; }
        set { qrImage.texture = value; }
    }
}
