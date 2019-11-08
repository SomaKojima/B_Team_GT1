using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWarp : MonoBehaviour
{
    [SerializeField]
    Transform position;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = position.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
