using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationMovementState : PlayerAnimationState
{
    public PlayerAnimationMovementState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates estate) : base(context, estate)
    {
        PlayerAnimationStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("MovementStateäJén");
        Context.animator.SetBool("Walk", true);
    }
    public override void ExitState()
    {
        Debug.Log("MovementStateèIóπ");
        Context.animator.SetBool("Walk", false);
    }
    public override void UpdateState()
    {
        Debug.Log("MovementStateíÜ");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        GetNextState();
    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return PlayerAnimationStates.Idle;
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
