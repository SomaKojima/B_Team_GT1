using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfCommonSelectIcon : MonoBehaviour
{
    List<CommonSelectIcon> selectIcons = new List<CommonSelectIcon>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CommonSelectIcon icon in selectIcons)
        {
            if (icon.IsDownPointer)
            {
                icon.OnClickProcess();
            }
        }
    }

    public void Add(CommonSelectIcon icon)
    {
        selectIcons.Add(icon);
    }

    public List<CommonSelectIcon> SelectIcons
    {
        get { return selectIcons; }
    }
}
