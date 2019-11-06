using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour
{
    [SerializeField]
    Scrollbar verticalBar;

    [SerializeField]
    Transform scrollArea;

    bool isValueChange = false;
    int endCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endCount != scrollArea.childCount)
        {
            Debug.Log("aa");
            verticalBar.value = 1.0f;
        }
        endCount = scrollArea.childCount;
    }

    public void OnValueChange()
    {
        isValueChange = true;
        Debug.Log("change");
    }
}
