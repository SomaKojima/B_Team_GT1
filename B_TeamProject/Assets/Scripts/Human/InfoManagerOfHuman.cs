using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfHuman : MonoBehaviour
{
    List<InfoOfHuman> humans = new List<InfoOfHuman>();
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 人間の追加
    public void AddHumans(InfoOfHuman info)
    {
        humans.Add(info);
    }

    // 人間の削除
    public void DeleteHuman(InfoOfHuman info)
    {
        humans.Remove(info);
    }

    // 人種別に人間を取得
    public InfoOfHuman[] GetHumansOf(InfoOfHuman.HUMAN_TYPE type)
    {
        List<InfoOfHuman> buf = new List<InfoOfHuman>();

        foreach (InfoOfHuman info in humans)
        {
            if (info.Type == type)
            {
                buf.Add(info);
            }
        }

        return buf.ToArray();
    }

    // 人種別にリストから消す
    public void DeleteHumansOf(InfoOfHuman.HUMAN_TYPE type)
    {
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            if (humans[i].Type == type)
            {
                humans.RemoveAt(i);
            }
        }
    }

    public InfoOfHuman[] GetHumans()
    {
        return humans.ToArray();
    }
    
}
