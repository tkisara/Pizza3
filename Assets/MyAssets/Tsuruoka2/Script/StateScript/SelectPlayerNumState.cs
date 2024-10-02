using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static SelectStateMachine;

public class SelectPlayerNumState : SelectState
{
    private GameObject _textObj;
    private Text _text;
    //----------------------------------------------------------------------------------------------
    public SelectPlayerNumState(SelectStateContext context, SelectStateMachine.SelectStates estate) : base(context, estate)
    {
        SelectStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("PlayerNumState開始");
        //セレクト画面を表示する
        Context.canvass[Context.canvasNumber].gameObject.SetActive(true);
        _textObj = GameObject.Find("PlayerNumText");
        _text = _textObj.GetComponent<Text>();
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("PlayerNumState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("PlayerNumState中");
        _text.text=Context.playerNum.ToString();
        GetNextState();

    }
    //----------------------------------------------------------------------------------------------
    //
    public override SelectStateMachine.SelectStates GetNextState()
    {
        return StateKey;
    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れたら)
    public override void OnTriggerEnter(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れてる間)
    public override void OnTriggerStay(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(抜けたら)
    public override void OnTriggerExit(Collider other)
    {

    }
}
