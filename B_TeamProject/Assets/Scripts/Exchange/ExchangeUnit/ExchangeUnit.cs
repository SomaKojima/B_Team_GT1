using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUnit
{
    // 提示される人間
    List<InfoOfHuman> presentationHumans = new List<InfoOfHuman>();


    // 必要となる人間
    List<InfoOfHuman> necessatyHumans = new List<InfoOfHuman>();

    int id = 0;
    
    /// <summary>
    /// 人間の情報をランダムで設定する
    /// </summary>
    public void RandomSet()
    {
        int random = Random.Range(1, 5);
        for (int i = 0; i < random; i++)
        {
            InfoOfHuman human = new InfoOfHuman();
            human.RandomSet();
            presentationHumans.Add(human);
        }

        random = Random.Range(1, 5);
        for (int i = 0; i < random; i++)
        {
            InfoOfHuman human = new InfoOfHuman();
            human.RandomSet();
            necessatyHumans.Add(human);
        }
    }


    public void AddPresentation(InfoOfHuman info)
    {
        presentationHumans.Add(info);
    }

    public void AddNecessaty(InfoOfHuman info)
    {
        necessatyHumans.Add(info);
    }

    public List<InfoOfHuman> PresentationHumans
    {
        get { return presentationHumans; }
    }

    public List<InfoOfHuman> NecessatyHumans
    {
        get { return necessatyHumans; }
    }
    
    public int ID
    {
        get;
        set;
    }
}