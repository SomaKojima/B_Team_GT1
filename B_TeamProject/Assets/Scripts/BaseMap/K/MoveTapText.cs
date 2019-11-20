using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTapText : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    Transform startPos;

    [SerializeField]
    Transform endPos;


    float rot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += speed;

        if (rot > 360) rot = 0;

        obj.transform.position = Vector3.Slerp(startPos.position, endPos.position, Mathf.Cos(Mathf.Deg2Rad * rot));
    }
}
