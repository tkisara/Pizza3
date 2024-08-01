using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    public enum StateType
    {
        Idle,
        Movement,
        Dead
    }
    float x, z;
    public StateType _currentState;
    private StateType _nextState;
    static float _speed=20f;
    static float _impulse = 100f;
    [SerializeField] private int _PlayerNum;

    // Start is called before the first frame update
    void Start()
    {
        IdleStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case StateType.Idle:
                IdleUpdate();
                break;
            case StateType.Movement:
                MovementUpdate();
                break;
            case StateType.Dead:
                DeadUpdate();
                break;
        }
        if (_currentState != _nextState)
        {
            switch (_currentState)
            {
                case StateType.Idle:
                    IdleEnd();
                    break;
                case StateType.Movement:
                    MovementEnd();
                    break;
                case StateType.Dead:
                    DeadEnd();
                    break;
            }

            _currentState = _nextState;
            switch (_currentState)
            {
                case StateType.Idle:
                    IdleStart();
                    break;
                case StateType.Movement:
                    MovementStart();
                    break;
                case StateType.Dead:
                    DeadStart();
                    break;
            }
        }
    }
    /// <summary>
    /// ステート遷移
    /// </summary>
    /// <param name="nextState"></param>
    private void ChangeState(StateType nextState)
    {
        _nextState = nextState;
    }
    //----------------------------
    //IdleState
    private void IdleStart()
    {

    }
    private void IdleUpdate()
    {
        Debug.Log("Idleだよ");
        x = Input.GetAxisRaw("Horizontal" + _PlayerNum);
        z = Input.GetAxisRaw("Vertical" + _PlayerNum);
        if (x != 0 || z != 0)
        {
            ChangeState(StateType.Movement);
        }
        
    }
    private void IdleEnd()
    {

    }
    //----------------------------
    //MovementState
    private void MovementStart()
    {

    }
    private void MovementUpdate()
    {
        Debug.Log("Movementだよ");

        x = Input.GetAxisRaw("Horizontal" + _PlayerNum);
        z = Input.GetAxisRaw("Vertical" + _PlayerNum);
        transform.Translate(new Vector3(x, 0, z) * _speed * Time.deltaTime); //+= new Vector3(x, 0, z) * _speed * Time.deltaTime;
       if (x == 0 && z == 0)
        {
            ChangeState(StateType.Idle);
        }
        Debug.Log(z);
        
    }
    private void MovementEnd()
    {

    }
    //----------------------------
    //DeadState
    private void DeadStart()
    {

    }
    private void DeadUpdate()
    {

    }
    private void DeadEnd()
    {

    }
    //----------------------------
    //当たり判定
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("当たった");
            Rigidbody _col = col.gameObject.GetComponent<Rigidbody>();
            Vector3 _impulseVec = (_col.position - transform.position).normalized * _impulse;
            _col.AddForce(_impulseVec, ForceMode.Impulse);
        }
    }

}
