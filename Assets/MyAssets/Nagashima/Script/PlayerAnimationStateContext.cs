using UnityEngine;

public class PlayerAnimationStateContext
{
    private Animator _animator;
    private PlayerMovementStateMachine _pm;

    public PlayerAnimationStateContext(Animator animator, PlayerMovementStateMachine pm)
    {
        _animator = animator;
        _pm = pm;

    }
    public Animator animator => _animator;

    public PlayerMovementStateMachine pm => _pm;

}
