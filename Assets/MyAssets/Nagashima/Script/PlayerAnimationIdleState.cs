using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationIdleState : PlayerAnimationState
{
    private PlayerMovementStateMachine pMovementStateMachine = MonoBehaviour.FindObjectOfType<PlayerMovementStateMachine>();
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
        Context.animator.SetBool("Idle", false);
    }
    public override void UpdateState()
    {
        Debug.Log("IdleStateíÜ");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //MonoBehaviour.Destroy();
        }
        GetNextState();
    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        if(pMovementStateMachine._currentState == PlayerMovementStateMachine.StateType.Idle)
        {
            return PlayerAnimationStates.Movement;
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
