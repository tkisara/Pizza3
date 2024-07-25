using UnityEngine;

public class EnemyMovementState : EnemyState
{
    public EnemyMovementState(EnemyStateContext context, EnemyStateMachine.EnemyStates estate) : base(context, estate)
    {
        EnemyStateContext Context = context;
    }


    public override void EnterState()
    {
        Debug.Log("MovementStateäJén");
    }

    public override void ExitState()
    {
        Debug.Log("MovementStateèIóπ");
    }

    public override void UpdateState()
    {
        Debug.Log("MovementStateíÜ");
    }
    public override EnemyStateMachine.EnemyStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return EnemyStateMachine.EnemyStates.Dead;
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