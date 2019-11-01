using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMouse : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    // Start is called before the first frame update
    Vector3 m_clickPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        m_clickPosition = Input.mousePosition;
        m_clickPosition.z = 10.0f;
        Vector2 worldMousePos = camera.ScreenToWorldPoint(m_clickPosition);

        transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);
    }

  

}
