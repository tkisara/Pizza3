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
        Dead
    }

    private PlayerStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;
    [SerializeField] private Transform _myTransform;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private float _playerSpeed = 30;

    void Awake()
    {
        NullMessage();
        _context = new PlayerStateContext(_rb,_col,_playerSpeed,_myTransform,_enemyObject);
        InitializeStates();
    }

    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rbがnullです");
        Assert.IsNotNull(_col, "_colがnullです");
        Assert.IsNotNull(_enemyObject, "_colがnullです");
    }
    // PlayerStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        States.Add(PlayerStates.Idle, new PlayerIdleState(_context, PlayerStates.Idle));
        States.Add(PlayerStates.Movement, new PlayerMovementState(_context, PlayerStates.Movement));
        States.Add(PlayerStates.Dead, new PlayerDeadState(_context, PlayerStates.Dead));
        //IdleStateを最初に呼び出す
        CurrentState = States[PlayerStates.Idle];
    }
}
