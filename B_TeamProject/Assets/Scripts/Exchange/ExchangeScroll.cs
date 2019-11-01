using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeScroll : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを押した時
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
        }

       // Input.mou
    }

    // スクロールの処理
    public void Scroll(float movement)
    {
        float y = gameObject.transform.position.y + movement;

        gameObject.transform.position = new Vector3(
             gameObject.transform.position.x,
             y,
              gameObject.transform.position.z
            );
    }
}
