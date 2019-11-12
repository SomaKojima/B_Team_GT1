using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_RankScript : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    GameObject m_particle = null;

    //パーティクルの出現
    bool m_flag = false;

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(15, 15, 15);
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    float m_time;

    public void MoveObject()
    {

        m_time += Time.deltaTime;


        this.gameObject.transform.eulerAngles += new Vector3(0, 0, 90);

        this.gameObject.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);

        this.gameObject.transform.position -= new Vector3(0, 0, -0.5f);

        if (gameObject.transform.localScale.x < 5)
        {
            this.gameObject.transform.localScale = new Vector3(5, 5, 5);

        }

        if (this.gameObject.transform.position.z > 0)
        {
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            if (m_time > 1.5f)
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                m_flag = true;

                if (m_flag)
                {
                    ParticleOn();
                }
            }

        }
    }

    void ParticleOn()
    {
        m_particle.SetActive(true);
    }

}
