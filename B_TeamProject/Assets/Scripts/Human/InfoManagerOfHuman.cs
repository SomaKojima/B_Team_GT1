using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfHuman : MonoBehaviour
{
    List<InfoOfHuman> humans = new List<InfoOfHuman>();

    List<List<List<InfoOfHuman>>> Place_Type_Humans = new List<List<List<InfoOfHuman>>>();

    bool isChange = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (int)InfoOfHuman.PLACE_TYPE.MAX; i++)
        {
            Place_Type_Humans.Add(new List<List<InfoOfHuman>>());
            for (int j = 0; j < (int)InfoOfHuman.HUMAN_TYPE.MAX; j++)
            {
                Place_Type_Humans[i].Add(new List<InfoOfHuman>());
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        foreach (InfoOfHuman human in humans)
        {
        }
    }

    private void LateUpdate()
    {
        isChange = false;
    }

    // 人間の追加
    public void AddHumans(InfoOfHuman info)
    {
        Debug.Log(humans.Count);
        humans.Add(info);
        Place_Type_Humans[(int)info.PlaceType][(int)info.Type].Add(info);
        isChange = true;
    }

    public void AddHumans(List<InfoOfHuman> list)
    {
        foreach (InfoOfHuman human in list)
        {
            AddHumans(human);
        }
    }

    // 人間の削除
    public void DeleteHuman(InfoOfHuman info, int index = -1)
    {
        Debug.Log(humans.Count);
        if (index < 0)
        {
            humans.Remove(info);
        }
        else
        {
            humans.RemoveAt(humans.IndexOf(info));
        }
        Place_Type_Humans[(int)info.PlaceType][(int)info.Type].Remove(info);
        isChange = true;
    }

    // 人種別にリストから消す
    public void DeleteHumansOf(InfoOfHuman.HUMAN_TYPE type, int _count)
    {
        int count = _count;
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            // 特定数消した
            if (count <= 0)
            {
                break;
            }

            if (humans[i].Type == type)
            {
                DeleteHuman(humans[i], i);
                count--;
            }
        }
    }

    public void DeleteHumansOf(List<InfoOfHuman> list)
    {
        if (list.Count == 0) return;
        int[] count = new int[(int)InfoOfHuman.HUMAN_TYPE.MAX];
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            count[i] = 0;
        }
        foreach (InfoOfHuman human in list)
        {
            count[(int)human.Type] += 1;
        }
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            DeleteHumansOf((InfoOfHuman.HUMAN_TYPE)i, count[i]);
        }
    }

    // 人種別に人間を取得
    public List<InfoOfHuman> GetHumansOf(InfoOfHuman.HUMAN_TYPE type)
    {
        List<InfoOfHuman> buf = new List<InfoOfHuman>();
        foreach (InfoOfHuman info in humans)
        {
            if (info.Type == type)
            {
                buf.Add(info);
            }
        }

        return new List<InfoOfHuman>(buf);
    }

    public bool CheckHumansOf(List<InfoOfHuman> list)
    {
        if (list.Count == 0) return true;

        int[] count = new int[(int)InfoOfHuman.HUMAN_TYPE.MAX];
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            count[i] = 0;
        }
        foreach (InfoOfHuman human in list)
        {
            count[(int)human.Type] += 1;
            if (count[(int)human.Type] > GetCountOf(human.Type))
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckHumansOf(InfoOfHuman.HUMAN_TYPE type, int count)
    {
        if (GetCountOf(type) > count) return true;

        return false;
    }

    public int GetCountOf(InfoOfHuman.HUMAN_TYPE type)
    {
        int answer = 0;
        for (int i = 0; i < (int)InfoOfHuman.PLACE_TYPE.MAX; i++)
        {
            answer += Place_Type_Humans[i][(int)type].Count;
        }
        return answer;
    }

    public List<InfoOfHuman> GetHumans()
    {
        return humans;
    }

    public int GetCountOf(InfoOfHuman.PLACE_TYPE _type)
    {
        int answer = 0;
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            answer += Place_Type_Humans[(int)_type][i].Count;
        }
        return answer;
    }

    public List<InfoOfHuman> GetHumansOf(InfoOfHuman.HUMAN_TYPE type, InfoOfHuman.PLACE_TYPE _placeType)
    {
        return Place_Type_Humans[(int)_placeType][(int)type];
    }

    public bool IsChange
    {
        get { return isChange; }
    }
}
