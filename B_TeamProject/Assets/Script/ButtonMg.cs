using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMg : MonoBehaviour
{
    bool flag = true;
    public void OnClick()
    {
        // Buttonsを非表示する
        Debug.Log("ButtonMg click!");
        if (flag == true)
        {
            MyCanvas.SetActive("Button", false);
            MyCanvas.SetActive("Button2", false);
            flag = false;
            Debug.Log(flag);
        }
        else
        {
            MyCanvas.SetActive("Button", true);
            MyCanvas.SetActive("Button2", true);
            flag = true;
            Debug.Log(flag);
        }
    }
}
