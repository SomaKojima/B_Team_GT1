using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMouse : MonoBehaviour
{
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
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(m_clickPosition);

        transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Base1")
        {
            Debug.Log("jhfhe");
            if (Input.GetMouseButton(0))
            {
                Debug.Log("jhfhe");
                //SceneManager.LoadScene("GameScene");
            }
        }
    }

}
