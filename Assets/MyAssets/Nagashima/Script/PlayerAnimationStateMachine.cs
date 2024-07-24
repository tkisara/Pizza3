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
        Action,
        Dead
    }

    private PlayerAnimationStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;
    [SerializeField] private Animator _animator;

    void Awake()
    {
        NullMessage();
        _context = new PlayerAnimationStateContext(_rb, _col,_animator);
        InitializeStates();
    }
    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rbがnullです");
    }
    // PlayerStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        States.Add(PlayerAnimationStates.Idle, new PlayerAnimationIdleState(_context, PlayerAnimationStates.Idle));
        //IdleStateを最初に呼び出す
        CurrentState = States[PlayerAnimationStates.Idle];
    }
}
