using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerStateContext context, PlayerStateMachine.PlayerStates estate) : base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("DeadStateäJén");
    }

    public override void ExitState()
    {
        Debug.Log("DeadStateèIóπ");
    }

    public override void UpdateState()
    {
        Debug.Log("DeadStateíÜ");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return PlayerStateMachine.PlayerStates.Idle;
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