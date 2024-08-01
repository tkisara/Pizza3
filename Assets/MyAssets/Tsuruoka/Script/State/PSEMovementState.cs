using UnityEngine;
using static PSEStateMachine;

public class PSEMovementState : PSEState
{
    //----------------------------------------------------------------------------------------------
    public PSEMovementState(PSEStateContext context, PSEStateMachine.PSEStates estate) : base(context, estate)
    {
        PSEStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("MovementState開始");

        //歩く　ループ再生
        Context.audioSource.clip = Context.seclips[5]; //SE指定
        Context.audioSource.pitch = 0.8f; //再生速度
        Context.audioSource.loop = true; //ループ再生有無
        Context.audioSource.Play(); //再生
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("MovementState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("MovementState中");

        if(!Context.audioSource.isPlaying)
        {//音が再生されていない場合
            Context.audioSource.pitch = 0.8f;
            Context.audioSource.Play();
        }

        GetNextState();

    }
    //----------------------------------------------------------------------------------------------
    //
    public override PSEStateMachine.PSEStates GetNextState()
    {
        if (Context.pMovementStateMachine._currentState == PlayerMovementStateMachine.StateType.Idle)
        {
            return PSEStates.Idel;
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
        //他のプレイヤとぶつかったとき
        {
            Context.audioSource.Stop(); //歩く　ループ再生の停止
            Context.audioSource.pitch = 1;
            Context.audioSource.PlayOneShot(Context.seclips[2]); //接触
        }
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
