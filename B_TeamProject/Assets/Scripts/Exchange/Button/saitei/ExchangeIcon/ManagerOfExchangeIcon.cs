using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfExchangeIcon : MonoBehaviour
{
    List<ExchangeIcon> icons = new List<ExchangeIcon>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // リストに追加
    public void Add(ExchangeIcon _icon)
    {
        icons.Add(_icon);
    }

    public List<ExchangeIcon> Icons
    {
        get { return icons; }
    }
}
