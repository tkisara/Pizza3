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
        //Debug.Log("IdleStateäJén");
        Context.animator.SetBool("Idle", true);
    }
    public override void ExitState()
    {
        //Debug.Log("IdleStateèIóπ");
        Context.animator.SetBool("Idle", false);
    }
    public override void UpdateState()
    {
        //Debug.Log("IdleStateíÜ");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //MonoBehaviour.Destroy();
        }
        GetNextState();
    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        if(Context.pm._currentState == PlayerMovementStateMachine.StateType.Movement)
        {
            return PlayerAnimationStates.Movement;
        }
        if (Context.pm._currentState == PlayerMovementStateMachine.StateType.Jump)
        {
            return PlayerAnimationStates.Jump;
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
