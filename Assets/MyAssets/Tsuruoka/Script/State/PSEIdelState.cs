using UnityEngine;
using static PSEStateMachine;

public class PSEIdelState : PSEState
{
    //----------------------------------------------------------------------------------------------
    public PSEIdelState(PSEStateContext context, PSEStateMachine.PSEStates estate) : base(context, estate)
    {
        PSEStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("IdelState開始");
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("IdelState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("IdelState中");
        GetNextState();

    }
    //----------------------------------------------------------------------------------------------
    //
    public override PSEStateMachine.PSEStates GetNextState()
    {
        if (Context.pMovementStateMachine._currentState == PlayerMovementStateMachine.StateType.Jump)
        {
            return PSEStates.Jump;
        }
        if (Context.pMovementStateMachine._currentState == PlayerMovementStateMachine.StateType.Movement)
        {
            return PSEStates.Movement;
        }
        if (Context.pMovementStateMachine._currentState == PlayerMovementStateMachine.StateType.Dead)
        {
            return PSEStates.Dead;
        }
        return StateKey;
    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れたら)
    public override void OnTriggerEnter(Collider other)
    {
        //アイテムを拾ったとき
        string tag = other.tag;
        if(tag.Contains("Item"))
        {
            Context.audioSource.Stop(); //歩く　ループ再生の停止
            Context.audioSource.pitch = 1;
            Context.audioSource.PlayOneShot(Context.seclips[1]); //接触
        }
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
