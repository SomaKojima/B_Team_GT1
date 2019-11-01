using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcP_UIModeManager : MonoBehaviour
{
    public enum EXCP_UI_MODE
    {
        EXCP_UI_MODE_NONE = -1,
        SELECT_PLAYER,
        SELECT_EXCHANGE,
        EXCHANGE_QR_MODE,

        EXCP_UI_MODE_MAX
    };
    [SerializeField]
    GameObject selectPlayer;

    [SerializeField]
    GameObject selectExchange;
    
    [SerializeField]
    OKButton OK_Button;

    EXCP_UI_MODE mode = EXCP_UI_MODE.EXCP_UI_MODE_NONE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        ChangeMode(EXCP_UI_MODE.SELECT_PLAYER);
    }

    public void ChangeMode(EXCP_UI_MODE _mode)
    {
        mode = _mode;

        selectPlayer.SetActive(false);
        selectExchange.SetActive(false);
        switch (mode)
        {
            case EXCP_UI_MODE.SELECT_PLAYER:
                selectPlayer.SetActive(true);
                break;
            case EXCP_UI_MODE.SELECT_EXCHANGE:
                selectExchange.SetActive(true);
                break;
            case EXCP_UI_MODE.EXCHANGE_QR_MODE:
                Debug.Log("QR_MODE");
                break;
        }
    }
}
