using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcB_SelectExchange : MonoBehaviour
{
    const float CONTINUOUS_FRAME = 0.5f;
    const float CONTINUOUS_DURING_FRAME = 0.05f;
    const float CONTINUOUS_DURING_SCALE = 0.0f;

    [SerializeField]
    Text exchangeName;
    [SerializeField]
    Text countText;
    [SerializeField]
    Text currentCountText;

    int id = 0;

    int count = 0;
    int currentCount = 0;

    bool isPlus = false;
    bool isMinus = false;

    bool isFirst = false;
    
    bool isDownPointer = false;
    float continuousFrame = 0;
    float continuousDuringFrame = CONTINUOUS_FRAME;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString();
        currentCountText.text = "/ " + currentCount.ToString();
    }

    public void Initialize(string _name, int _id)
    {
        exchangeName.text = _name;
        count = 0;
        currentCount = 0;
        countText.text = count.ToString();
        currentCountText.text = "/ " + currentCount.ToString();

        id = _id;
    }

    void Plus()
    {
        count += 1;
        if (count > currentCount)
        {
            count = currentCount;
        }
    }

    void Minus()
    {
        count -= 1;
        if (count < 0)
        {
            count = 0;
        }
    }

    // 入力中の処理
    public void OnClickProcess()
    {
        if (IsClickProcess())
        {
            if (isPlus)
            {
                Plus();
            }
            else if (isMinus)
            {
                Minus();
            }
        }
    }

    // プラスボタンをクリック
    public void OnPlusClick()
    {
        isPlus = true;
    }

    // マイナスボタンをクリック
    public void OnMinusClick()
    {
        isMinus = true;
    }

    // 入力したときの処理
    public void OnDownPointer()
    {
        isDownPointer = true;
    }

    // 入力をやめたときの処理
    public void OnUpPointer()
    {
        isDownPointer = false;
        isFirst = false;
        isPlus = false;
        isMinus = false;
        continuousFrame = 0;
        continuousDuringFrame = CONTINUOUS_FRAME;
    }

    // 長押しの処理をするタイミングを返す
    bool CheckContinuous()
    {
        if (continuousFrame >= continuousDuringFrame)
        {
            continuousFrame = 0.0f;

            continuousDuringFrame *= CONTINUOUS_DURING_SCALE;
            if (continuousDuringFrame < CONTINUOUS_DURING_FRAME)
            {
                continuousDuringFrame = CONTINUOUS_DURING_FRAME;
            }
            return true;
        }
        continuousFrame += Time.deltaTime;

        return false;
    }

    // 入力の実行処理をするかどうか
    bool IsClickProcess()
    {
        if (isDownPointer)
        {
            if (!isFirst)
            {
                isFirst = true;
                return true;
            }
            else if (CheckContinuous())
            {
                return true;
            }
        }
        return false;
    }

    public int ID
    {
        get { return id; }
    }

    public int Count
    {
        get { return count; }
    }

    public bool IsPlus
    {
        get { return isPlus; }
    }

    public bool IsMinus
    {
        get { return isMinus; }
    }

    public int CurrentCount
    {
        set { currentCount = value; }
    }

    public bool IsDownPointer
    {
        get { return isDownPointer; }
    }
}
