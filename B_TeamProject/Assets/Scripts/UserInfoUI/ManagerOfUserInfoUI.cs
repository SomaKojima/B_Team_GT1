using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfUserInfoUI : MonoBehaviour
{
    [SerializeField]
    UserInfoUI p1;

    [SerializeField]
    UserInfoUI p2;

    [SerializeField]
    UserInfoUI p3;

    [SerializeField]
    UserInfoUI p4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        p4.gameObject.SetActive(false);
        p3.gameObject.SetActive(false);
        p2.gameObject.SetActive(false);
        p1.gameObject.SetActive(false);
    }

    public UserInfoUI GetPlayerInfoUI(int i)
    {
        switch (i)
        {
            case 0:
                return p1;
            case 1:
                return p2;
            case 2:
                return p3;
            case 3:
                return p4;
        }

        return null;
    }

    public void UpdateActive(int member)
    {
        if(member >= 4) p4.gameObject.SetActive(true);
        if(member >= 3) p3.gameObject.SetActive(true);
        if(member >= 2) p2.gameObject.SetActive(true);
        if(member >= 1) p1.gameObject.SetActive(true);
    }
}
