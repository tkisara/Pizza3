using UnityEngine;
using static SelectStateMachine;

public class SelectPlayerModelState : SelectState
{
    //----------------------------------------------------------------------------------------------
    public SelectPlayerModelState(SelectStateContext context, SelectStateMachine.SelectStates estate) : base(context, estate)
    {
        SelectStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("PlayerModelState開始");
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("PlayerModelState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("PlayerModelState中");
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
