using UnityEngine;

public abstract class EnemyState : BaseState<EnemyStateMachine.EnemyStates>
{
    protected EnemyStateContext Context;

    public EnemyState(EnemyStateContext context, EnemyStateMachine.EnemyStates statekey) : base(statekey)
    {
        Context = context;
    }
}
