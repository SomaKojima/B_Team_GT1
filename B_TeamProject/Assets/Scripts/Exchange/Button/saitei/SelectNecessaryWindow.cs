using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNecessaryWindow : MonoBehaviour
{
    [SerializeField]
    Text necessaryText;

    [SerializeField]
    Text countText;

    [SerializeField]
    Text excCountText;

    [SerializeField]
    Button exchangeButton;

    [SerializeField]
    UIButtonClick CancelButton;

    [SerializeField]
    FactoryOfCommonSelectIcon factorySelectIcon;

    [SerializeField]
    ManagerOfCommonSelectIcon managerSelectIcon;

    int necessary = 0;

    bool isExchange = false;

    int count = 0;

    int id = 0;

    public void Initialize(int _necessary, int _id)
    {
        necessary = _necessary;
        necessaryText.text = necessary.ToString();
        count = 0;

        id = _id;
    }

    // Start is called before the first frame update
    void Start()
    {
        // アイコンを作成
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            managerSelectIcon.Add(factorySelectIcon.Create((InfoOfHuman.HUMAN_TYPE)i));
        }
        for (int i = 0; i < (int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX; i++)
        {
            managerSelectIcon.Add(factorySelectIcon.Create((InfoOfBuildingResource.BUILDING_RESOUCE_TYPE)i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 合計値の更新
        count = 0;
        foreach (CommonSelectIcon icon in managerSelectIcon.SelectIcons)
        {
            count += icon.Count;
        }
        countText.text = count.ToString();

        // 交換ボタンの更新
        if (count < necessary)
        {
            exchangeButton.interactable = false;
        }
        else
        {
            exchangeButton.interactable = true;
        }

        // 交換する数を更新
        excCountText.text = "x" + ExcCount().ToString();

        // 戻るボタン
        if (CancelButton.IsClick)
        {
            CancelButton.OnClickProcess();
            this.gameObject.SetActive(false);
        }

    }
    

    public void OnExchangeClickProcess()
    {
        isExchange = false;
    }

    public void OnExchangeClick()
    {
        isExchange = true;
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public bool IsExchange
    {
        get { return isExchange; }
    }

    public ManagerOfCommonSelectIcon MgrCommonSelectIcon
    {
        get { return managerSelectIcon; }
    }

    public int[] GetHumanCount()
    {
        int[] count = new int[(int)InfoOfHuman.HUMAN_TYPE.MAX];
        for (int i = 0; i < (int)InfoOfHuman.HUMAN_TYPE.MAX; i++)
        {
            count[i] = 0;
        }

        foreach (CommonSelectIcon icon in managerSelectIcon.SelectIcons)
        {
            if (icon.HumanType != InfoOfHuman.HUMAN_TYPE.NONE)
            {
                count[(int)icon.HumanType] = icon.Count;
            }
        }

        return count;
    }

    public int[] GetBRCount()
    {
        int[] count = new int[(int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX];
        for (int i = 0; i < (int)InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.MAX; i++)
        {
            count[i] = 0;
        }

        foreach (CommonSelectIcon icon in managerSelectIcon.SelectIcons)
        {
            if (icon.BRType != InfoOfBuildingResource.BUILDING_RESOUCE_TYPE.NONE)
            {
                count[(int)icon.BRType] = icon.Count;
            }
        }

        return count;
    }

    public int ID
    {
        get { return id; }
    }

    public int ExcCount()
    {
        if (necessary != 0)
        {
            return count / necessary;
           
        }
        else
        {
            if (count == 0) return 1;
            return count;
        }
    }
}
