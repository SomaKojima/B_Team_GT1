using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUnit
{
    // 提示される人間
    List<InfoOfHuman> presentationHumans = new List<InfoOfHuman>();
    List<InfoOfBuildingResource> presentationBRs = new List<InfoOfBuildingResource>();


    // 必要となる人間
    List<InfoOfHuman> necessatyHumans = new List<InfoOfHuman>();
    List<InfoOfBuildingResource> necessatyBRs = new List<InfoOfBuildingResource>();

    // 必要となる人間・資源の数
    int necessaryCount = -1;

    int id = 0;

    public void Initialize(List<InfoOfHuman> presHumans, List<InfoOfBuildingResource> presBRs, List<InfoOfHuman> neceHumans, List<InfoOfBuildingResource> neceBRs, int _necessaryCount = -1)
    {
        if (presHumans != null) presentationHumans = presHumans;
        if (presBRs != null) presentationBRs = presBRs;
        if (neceHumans != null) necessatyHumans = neceHumans;
        if (neceBRs != null) necessatyBRs = neceBRs;
        necessaryCount = _necessaryCount;
    }

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

    public List<InfoOfHuman> PresentationHumans
    {
        get { return presentationHumans; }
    }

    public List<InfoOfBuildingResource> PresentationBRs
    {
        get { return presentationBRs; }
    }

    public List<InfoOfHuman> NecessatyHumans
    {
        get { return necessatyHumans; }
    }

    public List<InfoOfBuildingResource> NecessatyBRs
    {
        get { return necessatyBRs; }
    }

    public int ID
    {
        get;
        set;
    }

    public int NecessaryCount
    {
        get { return necessaryCount; }
    }

}