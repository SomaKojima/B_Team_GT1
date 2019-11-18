using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeIcon : MonoBehaviour
{
    [SerializeField]
    Text numText;

    [SerializeField]
    Image image;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count != 0)
        {
            numText.text = count.ToString();
        }
    }

    public void Initialize(int num, Sprite sprite)
    {
        numText.text = "";
        count = num;

        if (count != 0)
        {
            numText.text = count.ToString();
        }
        image.sprite = sprite;
        //image.SetNativeSize();
    }
}
