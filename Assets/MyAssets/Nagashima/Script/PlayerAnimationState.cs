using UnityEngine;

public abstract class PlayerAnimationState : BaseState<PlayerAnimationStateMachine.PlayerAnimationStates>
{
    protected PlayerAnimationStateContext Context;

    public PlayerAnimationState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates statekey) : base(statekey)
    {
        Context = context;
    }
}

