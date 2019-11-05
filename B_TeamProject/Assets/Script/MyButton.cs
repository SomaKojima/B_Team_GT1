using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        Debug.Log("Button click!");
        // 非表示にする
        gameObject.SetActive(false);
        // Button2を表示する
        MyCanvas.SetActive("Button2", true);
    }
}
