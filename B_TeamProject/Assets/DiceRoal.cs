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
    int score;

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
        
        if (roalFlag)
        {         
            dice.transform.Rotate(new Vector3(0, 10, 25));     
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            //dice.transform.Rotate(new Vector3(0, 0, 0));
        }
        if(!one&&roalFlag)
        {
            count++;
            if (count < 20)
            {
                speed = new Vector3(0.2f, 0.5f, 0);
            }
            else if (count<30)
            {
                speed = new Vector3(0.2f, 0.25f, 0);
            }
            else if (count < 40)
            {
                speed = new Vector3(0.2f, -0.25f, 0);
            }
            else if (count < 60)
            {
                speed = new Vector3(0.2f, -0.5f, 0);
            }
            else
            {
                speed = new Vector3(0, 0, 0);
                roalFlag = false;
                score = (int)Random.Range(1.0f, 6.99f);
                Debug.Log(score);
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
