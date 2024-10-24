using UnityEngine;

public class PlayerMovementStateMachine : MonoBehaviour
{
    public enum StateType
    {
        Idle,
        Movement,
        Jump,
        Dead
    }
    public float DefaultSpeed = 20f;
    public float DefaultImpulse = 30f;
    public float BufSpeed = 25f;
    public float BufImpulse = 40f;
    public float BufDurationSpeed = 10;
    public float BufDurationImpulse = 10;

    float x, z;
    public StateType _currentState;
    private StateType _nextState;
    
    [SerializeField] private int _PlayerNum;

    private  Rigidbody _rb;

    public float _speed;
    public float _impulse;
    bool _isItemImpulse = false;
    bool _isItemSpeed = false;
    float _itemTimerImpulse = 0;
    float _itemTimerSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody>();
        _speed = DefaultSpeed;
        _impulse = DefaultImpulse;
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
            case StateType.Jump:
                JumpUpdate();
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
                case StateType.Jump:
                    JumpEnd();
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
                case StateType.Jump:
                    JumpStart();
                    break;
                case StateType.Dead:
                    DeadStart();
                    break;
            }
        }

        UpdateBuf();
    }

    void UpdateBuf()
    {
        if (_isItemSpeed)
        {
            _itemTimerSpeed += Time.deltaTime;
            if(_itemTimerSpeed >= BufDurationSpeed)
            {
                _isItemSpeed = false;
                _speed = DefaultSpeed;
            }
        }
        if (_isItemImpulse)
        {
            _itemTimerImpulse += Time.deltaTime;
            if (_itemTimerImpulse >= BufDurationImpulse)
            {
                _isItemImpulse = false;
                _impulse = DefaultImpulse;
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
        //@@Debug.Log("Idleだよ");
        x = Input.GetAxis("Horizontal"+_PlayerNum);
        z = Input.GetAxis("Vertical" + _PlayerNum); 
        if (x != 0 || z != 0)
        {
            ChangeState(StateType.Movement);
        }
        if (transform.position.y < -10)
        {
            ChangeState(StateType.Dead);
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
        
        x = Input.GetAxis("Horizontal" + _PlayerNum);
        z = Input.GetAxis("Vertical" + _PlayerNum);
        //transform.position += new Vector3(x, 0, z) * _speed * Time.deltaTime;
        Vector3 _movement = new Vector3(x, 0, z);
        _rb.MovePosition(transform.position + _movement * _speed * Time.deltaTime);
        if (x == 0 && z == 0)
        {
            ChangeState(StateType.Idle);
        }
        if (transform.position.y < -10)
        {
            ChangeState(StateType.Dead);
        }
    }
    private void MovementEnd()
    {

    }
    //----------------------------
    //JumpState
    private void JumpStart()
    {

    }
    private void JumpUpdate()
    {

    }
    private void JumpEnd()
    {

    }
    //----------------------------
    //DeadState
    private void DeadStart()
    {
        Destroy(this.gameObject);
        Debug.Log("死んだ");
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
        string tag = col.gameObject.tag;
        if (tag.Contains("Player"))
        {
            Debug.Log("当たった");
            Rigidbody _col = col.gameObject.GetComponent<Rigidbody>();
            Vector3 _impulseVec = (_col.position - transform.position).normalized * _impulse;
            _col.AddForce(_impulseVec, ForceMode.Impulse);
        }
        
    }

    public void StartBufImpulse()
    {
        _impulse = BufImpulse;
        _itemTimerImpulse = 0;
        _isItemImpulse = true;
        Debug.Log("_impulse:" + _impulse);
    }

    public void StartBufSpeed()
    {
        _speed = BufSpeed;
        _itemTimerSpeed = 0;
        _isItemSpeed = true;
        Debug.Log("_speed:" + _speed);
    }
}
