using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    // テキストの表示・非表示の切り替え
    public void ChangeEnabled(Text textComponent)
    {
        // 非表示
        if (textComponent.enabled)
        {
            textComponent.enabled = false;
        }

        // 表示
        else
        {
            textComponent.enabled = true;
        }
    }
}
