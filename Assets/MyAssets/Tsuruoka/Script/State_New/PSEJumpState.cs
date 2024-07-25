using UnityEngine;
using static PSEStateMachine;

public class PSEJumpState : PSEState
{
    //----------------------------------------------------------------------------------------------
    public PSEJumpState(PSEStateContext context, PSEStateMachine.PSEStates estate) : base(context, estate)
    {
        PSEStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("JumpState開始");
        Context.audioSource.PlayOneShot(Context.seclips[3]); //ジャンプ
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("JumpState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("JumpState中");
        GetNextState();

    }
    //----------------------------------------------------------------------------------------------
    //
    public override PSEStateMachine.PSEStates GetNextState()
    {
        return StateKey;
    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れたら)
    public override void OnTriggerEnter(Collider other)
    {
        //アイテムを拾ったとき
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
