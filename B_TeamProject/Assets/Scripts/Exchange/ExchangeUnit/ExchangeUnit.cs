﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeUnit
{
    // 提示される人間
    InfoOfHuman presentationHuman = new InfoOfHuman();

    // 必要となる人間
    InfoOfHuman necessatyHuman = new InfoOfHuman();

    int id = 0;

    public void Initialize(InfoOfHuman presentation, InfoOfHuman necessaty)
    {
        presentationHuman = presentation;
        necessatyHuman = necessaty;
    }
    
    /// <summary>
    /// 人間の情報をランダムで設定する
    /// </summary>
    public void RandomSet()
    {
        presentationHuman.RandomSet();
        necessatyHuman.RandomSet();
    }

    public InfoOfHuman PresentationHuman
    {
        get { return presentationHuman; }
    }

    public InfoOfHuman NecessatyHuman
    {
        get { return necessatyHuman; }
    }
    
    public int ID
    {
        get;
        set;
    }
}