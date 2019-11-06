using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogScroll : MonoBehaviour
{
    [SerializeField]
    RectTransform maskRect;

    [SerializeField]
    Scrollbar verticalScrollbar;

    [SerializeField]
    Scrollbar horizonScrollbar;

    RectTransform rectTransform;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ///----------------------------------------------
        /// 縦スクロール
        ///----------------------------------------------
        rectTransform.localPosition = new Vector3(
            rectTransform.localPosition.x,
            ScrollValue(rectTransform.sizeDelta.y, maskRect.sizeDelta.y, startPosition.y, verticalScrollbar.value),
            rectTransform.localPosition.z
            );


        ///----------------------------------------------
        /// 横スクロール
        ///----------------------------------------------
        rectTransform.localPosition = new Vector3(
            ScrollValue(rectTransform.sizeDelta.x, maskRect.sizeDelta.x, startPosition.x, horizonScrollbar.value, true),
            rectTransform.localPosition.y,
            rectTransform.localPosition.z
            );
    }

    float ScrollValue(float size, float maskSize, float startPosition, float value, bool turn = false)
    {
        size -= maskSize;
        if (size < 0)
        {
            size = 0;
        }

        if (turn)
        {
            return startPosition - size * value;
        }
        return startPosition + size * value;
    }
}

