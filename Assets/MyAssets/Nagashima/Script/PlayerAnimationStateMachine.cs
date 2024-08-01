using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAnimationStateMachine : StateManager<PlayerAnimationStateMachine.PlayerAnimationStates>
{
    /// <summary>
    /// PlayerStateMachineで扱うStateの種類
    /// </summary>
    public enum PlayerAnimationStates
    {
        Idle,
        Movement,
        Jump,
        Action,
        Dead
    }

    private PlayerAnimationStateContext _context;

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementStateMachine pMovementStateMachine;

    void Awake()
    {
        NullMessage();
        _context = new PlayerAnimationStateContext(_animator,pMovementStateMachine);
        InitializeStates();
    }
    private void NullMessage()
    {
        Assert.IsNotNull(pMovementStateMachine, "_ないようがないよう");
    }
    // PlayerStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        States.Add(PlayerAnimationStates.Idle, new PlayerAnimationIdleState(_context, PlayerAnimationStates.Idle));
        States.Add(PlayerAnimationStates.Movement, new PlayerAnimationMovementState(_context, PlayerAnimationStates.Movement));
        States.Add(PlayerAnimationStates.Jump, new PlayerAnimationJumpState(_context, PlayerAnimationStates.Jump));
        //IdleStateを最初に呼び出す
        CurrentState = States[PlayerAnimationStates.Idle];
    }
}
