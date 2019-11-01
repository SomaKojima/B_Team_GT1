using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfEntityHuman : MonoBehaviour
{
    List<EntityHuman> humans = new List<EntityHuman>();
    List<EntityHuman> collectHumnas = new List<EntityHuman>();
    int[] countOfType = new int[(int)InfoOfHuman.HUMAN_TYPE.MAX];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize()
    {
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            countOfType[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectHumnas.Clear();
        // リクエスト別のリストに追加する
        foreach (EntityHuman human in humans)
        {
            if (human.IsCollect)
            {
                collectHumnas.Add(human);
            }
        }
    }

    public void Add(EntityHuman human)
    {
        humans.Add(human);
        if (0 <= (int)human.Type && (int)human.Type < (int)InfoOfHuman.HUMAN_TYPE.MAX)
        {
            countOfType[(int)human.Type] += 1;
        }
        Debug.Log("増えた人 ：" + human.Type.ToString());
    }
    
    // 人間の削除
    public void DeleteHuman(EntityHuman entity, int index = -1)
    {
        if (index < 0)
        {
            humans.Remove(entity);
        }
        else
        {
            humans.RemoveAt(humans.IndexOf(entity));
        }

        if (0 <= (int)entity.Type && (int)entity.Type < (int)InfoOfHuman.HUMAN_TYPE.MAX)
        {
            countOfType[(int)entity.Type] -= 1;
        }

        // ゲームオブジェクトの破棄
        Destroy(entity.gameObject);
        Debug.Log("減った人 ：" + entity.Type.ToString());
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


    public List<EntityHuman> CollectHumans
    {
        get { return collectHumnas; }
    }

    public int GetCountOf(InfoOfHuman.HUMAN_TYPE type)
    {
        return countOfType[(int)type];
    }

    public List<EntityHuman> Humans
    {
        get { return humans; }
    }
}
