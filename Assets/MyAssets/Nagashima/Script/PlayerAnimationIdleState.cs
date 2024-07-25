using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationIdleState : PlayerAnimationState
{
    public PlayerAnimationIdleState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates estate) : base(context, estate)
    {
        PlayerAnimationStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("IdleStateäJén");
        Context.animator.SetBool("Idle", true);
    }
    public override void ExitState()
    {
        Debug.Log("IdleStateèIóπ");
    }
    public override void UpdateState()
    {
        Debug.Log("IdleStateíÜ");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        return StateKey;
    }
    public override void OnTriggerEnter(Collider other)
    {

    }
    public override void OnTriggerStay(Collider other)
    {

    }
    public override void OnTriggerExit(Collider other)
    {

    }
}
