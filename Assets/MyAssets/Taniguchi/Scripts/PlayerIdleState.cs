using UnityEngine;

public class PlayerIdleState:PlayerState
{
    public PlayerIdleState(PlayerStateContext context,PlayerStateMachine.PlayerStates estate):base(context, estate)
    {
        PlayerStateContext Context = context;
    }

    /// <summary>
    /// 開始時に呼び出される関数
    /// </summary>
    public override void EnterState()
    {
        Debug.Log("IdleState開始");
    }
    /// <summary>
    /// Stateを抜けるときに呼び出される関数
    /// </summary>
    public override void ExitState()
    {

    }
    /// <summary>
    /// 呼び出されている間処理を行う関数
    /// </summary>
    public override void UpdateState()
    {
        Debug.Log("IdleState中");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        return StateKey;
    }
    /// <summary>
    /// 当たり判定(触れたら)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerEnter(Collider other)
    {

    }
    /// <summary>
    /// 当たり判定(触れてる間)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerStay(Collider other)
    {

    }
    /// <summary>
    /// 当たり判定(抜けたら)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerExit(Collider other)
    {

    }
}
