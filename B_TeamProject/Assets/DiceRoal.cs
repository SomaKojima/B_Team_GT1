using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoal : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 startPos;
    Vector3 speed;
    bool roalFlag;
    bool one;
    [SerializeField]
    private GameObject dice;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        roalFlag = false;
        one = true;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!one)
        {
            dice.transform.Rotate(new Vector3(0, 5, 15));
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            roalFlag = false;
            //dice.transform.Rotate(new Vector3(0, 0, 0));
        }
        if(!one&&!roalFlag)
        {
            count++;
            if (count < 20)
            {
                speed = new Vector3(-0.25f, 0.5f, 0);
            }
            else if (count<30)
            {
                speed = new Vector3(-0.25f, 0.25f, 0);
            }
            else if (count < 40)
            {
                dice.transform.Translate(new Vector3(-0.25f, -0.25f, 0));
            }
            else if (count < 60)
            {
                dice.transform.Translate(new Vector3(-0.25f, -0.5f, 0));
            }

            dice.transform.position += speed;
        }
    }

    public void OnClick()
    {
        if (one)
        {
            startPos = Input.mousePosition;
            roalFlag = true;
            one = false;
        }
    }
}
