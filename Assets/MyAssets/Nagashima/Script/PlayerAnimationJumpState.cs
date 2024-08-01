using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationJumpState : PlayerAnimationState
{
    public PlayerAnimationJumpState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates estate) : base(context, estate)
    {
        PlayerAnimationStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("JumpStateäJén");
        Context.animator.SetBool("Jump", true);
    }
    public override void ExitState()
    {
        Debug.Log("IdleStateèIóπ");
        Context.animator.SetBool("Jump", false);
    }
    public override void UpdateState()
    {
        Debug.Log("JumpStateíÜ");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //MonoBehaviour.Destroy();
        }
        GetNextState();
    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        if (Context.pm._currentState == PlayerMovementStateMachine.StateType.Dead)
        {
            return PlayerAnimationStates.Dead;
        }
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
