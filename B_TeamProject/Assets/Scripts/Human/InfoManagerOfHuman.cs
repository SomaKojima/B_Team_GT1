using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManagerOfHuman : MonoBehaviour
{
    List<InfoOfHuman> humans = new List<InfoOfHuman>();

    List<List<InfoOfHuman>> typeHumans = new List<List<InfoOfHuman>>();
    List<List<InfoOfHuman>> placeHumnas = new List<List<InfoOfHuman>>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            typeHumans.Add(new List<InfoOfHuman>());
        }

        for (int i = 0; i < (int)InfoOfHuman.PLACE_TYPE.MAX; i++)
        {
            placeHumnas.Add(new List<InfoOfHuman>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            typeHumans[(int)i].Clear();
        }

        for (int i = 0; i < (int)InfoOfHuman.PLACE_TYPE.MAX; i++)
        {
            placeHumnas[(int)i].Clear();
        }

        foreach (InfoOfHuman human in humans)
        {

            typeHumans[(int)human.Type].Add(human);

            if (human.PlaceType != InfoOfHuman.PLACE_TYPE.NONE)
            {
                placeHumnas[(int)human.PlaceType].Add(human);
            }
        }
    }

    // 人間の追加
    public void AddHumans(InfoOfHuman info)
    {
        humans.Add(info);

        Debug.Log("増えた人の情報 ：" + info.Type.ToString());
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
        if (index < 0)
        {
            humans.Remove(info);
        }
        else
        {
            humans.RemoveAt(humans.IndexOf(info));
        }
        Debug.Log("減った人の情報 ：" + info.Type.ToString());
    }

    // 人種別にリストから消す
    public void DeleteHumansOf(InfoOfHuman.HUMAN_TYPE type, int _count)
    {
        int count = _count;
        for (int i = humans.Count - 1; i >= 0; i--)
        {
            if (humans[i].Type == type)
            {
                DeleteHuman(humans[i], i);
                count--;
            }

            // 特定数消した
            if (count <= 0)
            {
                break;
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
            if (count[(int)human.Type] > typeHumans[(int)human.Type].Count)
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckHumansOf(InfoOfHuman.HUMAN_TYPE type, int count)
    {
        if (typeHumans[(int)type].Count > count) return true;

        return false;
    }

    public int GetCountOf(InfoOfHuman.HUMAN_TYPE type)
    {
        return typeHumans[(int)type].Count;
    }

    public List<InfoOfHuman> GetHumans()
    {
        return humans;
    }

    public int GetCountOf(InfoOfHuman.PLACE_TYPE _type)
    {
        return placeHumnas[(int)_type].Count;
    }

    public List<InfoOfHuman> GetHumansOf(InfoOfHuman.HUMAN_TYPE type, InfoOfHuman.PLACE_TYPE _placeType)
    {
        List<InfoOfHuman> buf = new List<InfoOfHuman>();
        foreach (InfoOfHuman info in placeHumnas[(int)_placeType])
        {
            if (info.Type == type)
            {
                buf.Add(info);
            }
        }

        return new List<InfoOfHuman>(buf);
    }
}
