using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogUI : MonoBehaviour
{
    [SerializeField]
    Text text;

    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(string _text)
    {
        text.text = _text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Text
    {
        set { text.text = value; }
    }

    public bool IsVisible
    {
        get { return isVisible; }
        set { isVisible = value; }
    }
}
