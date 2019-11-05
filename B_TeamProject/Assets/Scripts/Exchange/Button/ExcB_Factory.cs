using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcB_Factory : MonoBehaviour
{
    [SerializeField]
    GameObject prefabButton;

    [SerializeField]
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ExchangeButton CreateButton(ExchangeUnit unit)
    {
        List<string> presentation = new List<string>();
        List<int> presentationCount = new List<int>();
        List<string> necessaty = new List<string>();
        List<int> necessatyCount = new List<int>();
        foreach (InfoOfHuman human in unit.PresentationHumans)
        {
            presentation.Add(human.Type.ToString());
            presentationCount.Add(1);
        }
        foreach (InfoOfHuman human in unit.NecessatyHumans)
        {
            necessaty.Add(human.Type.ToString());
            necessatyCount.Add(1);
        }


        return CreateButton(presentation.ToArray(), presentationCount.ToArray(), presentation.Count, necessaty.ToArray(), necessatyCount.ToArray(), necessaty.Count, unit.ID);
    }

    public ExchangeButton CreateButton(string[] presentation, int[] presentationCount, int presentationSize, string[] necessaty, int[] necessatyCount, int necessatySize,  int id)
    {
        GameObject instance = Instantiate(prefabButton);
        instance.transform.SetParent(parent.transform, false);

        // ボタンの初期化処理
        ExchangeButton button = instance.GetComponent<ExchangeButton>();

        string pre = "";
        string nec = "";

        for (int i = 0; i < presentationSize; i++)
        {
            pre += presentation[i] + " x" + presentationCount[i] + "\n";
        }

        for (int i = 0; i < necessatySize; i++)
        {
            nec += necessaty[i] + " x" + necessatyCount[i] + "\n";
        }

        button.Initalize(pre, nec, id);
        return button;
    }
}
