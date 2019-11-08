using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log
{
    string text;

    public void Initialize(string _text)
    {
        text = _text;
    }

    public string Text
    {
        get { return text; }
    }
}
