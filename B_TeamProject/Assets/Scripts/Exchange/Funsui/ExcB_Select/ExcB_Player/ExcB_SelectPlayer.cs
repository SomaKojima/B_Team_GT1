using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcB_SelectPlayer : MonoBehaviour
{
    [SerializeField]
    Text text;
    
    int id = 0;

    bool isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(string _text, int _id)
    {
        text.text = _text;
        id = _id;
    }
    
    public void OnClickProcess()
    {
        isClick = false;
    }

    public void OnClick()
    {
        isClick = true;
    }

    public bool IsClick
    {
        get { return isClick; }
    }
}
