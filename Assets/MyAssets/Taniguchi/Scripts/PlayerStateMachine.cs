using UnityEngine;
using UnityEngine.Assertions;

public class PlayerStateMachine : StateManager<PlayerStateMachine.PlayerStates>
{
    /// <summary>
    /// PlayerStateMachineで扱うStateの種類
    /// </summary>
    public enum PlayerStates
    {
        Idle,
        Movement,
        Action,
        Dead
    }

    private PlayerStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;

    void Awake()
    {
        NullMessage();
        _context = new PlayerStateContext(_rb,_col);
        InitializeStates();
    }

    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rbがnullです");
    }
    // PlayerStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        States.Add(PlayerStates.Idle, new PlayerIdleState(_context, PlayerStates.Idle));
        //IdleStateを最初に呼び出す
        CurrentState = States[PlayerStates.Idle];
    }
}
