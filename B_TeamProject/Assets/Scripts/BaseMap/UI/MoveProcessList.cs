using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveProcessList : MonoBehaviour
{
    // 動作状態切り替え
    private bool moveState = false;

    // 動かすスピード
    [SerializeField]
    private float moveSpeed = 20.0f;

    // 表示/非表示用の基準位置
    private Vector3 listBasePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveList(bool visibleFlag, bool listState, ref GameObject listObject, float listWidth)
    {
        // 表示されておらず表示したかったら
        if (!visibleFlag && listState)
        {
            // 所持リストがスライド可能でなければ動かさない
            if (!moveState) return;
            // 画面右から左へスライド
            listObject.transform.localPosition -= new Vector3(moveSpeed, 0, 0);
            // 所持リスト表示/非表示用の基点設定
            listBasePos = listObject.transform.localPosition;
            listBasePos.x += (listWidth);
        }
        // 表示されており非表示にしたかったら
        else if (visibleFlag && !listState)
        {
            // 所持リストがスライド可能でなければ動かさない
            if (!moveState) return;
            // 画面右へスライド
            listObject.transform.localPosition += new Vector3(moveSpeed, 0, 0);
            // 所持リスト表示/非表示用の基点設定
            listBasePos = listObject.transform.localPosition;
            listBasePos.x -= (listWidth);
        }
        else
        {
            moveState = false;
        }
    }

    // 設定関数
    public bool MoveState { set {moveState = value;}}

    public Vector3 ListBasePos
    {
        set { listBasePos = value; }
        get { return listBasePos; }
    }
}
