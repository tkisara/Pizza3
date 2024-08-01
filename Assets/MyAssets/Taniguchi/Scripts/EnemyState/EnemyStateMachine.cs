using UnityEngine;
using UnityEngine.Assertions;
using static EnemyStateMachine;

public class EnemyStateMachine : StateManager<EnemyStateMachine.EnemyStates>
{
    /// <summary>
    /// PlayerStateMachineで扱うStateの種類
    /// </summary>
    public enum EnemyStates
    {
        Search,
        Movement,
        Dead
    }

    private EnemyStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;

    void Awake()
    {
        NullMessage();
        _context = new EnemyStateContext(_rb, _col);
        InitializeStates();
    }

    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rbがnullです");
    }
    // PlayerStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        States.Add(EnemyStates.Search, new EnemySearchState(_context, EnemyStates.Search));
        States.Add(EnemyStates.Movement, new EnemyMovementState(_context, EnemyStates.Movement));
        States.Add(EnemyStates.Dead, new EnemyDeadState(_context, EnemyStates.Dead));
        //IdleStateを最初に呼び出す
        CurrentState = States[EnemyStates.Search];
    }
}
