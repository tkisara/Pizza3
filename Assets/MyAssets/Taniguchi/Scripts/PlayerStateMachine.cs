using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private enum State
    {
        Idle,
        Movement,
        Dead
    }
    private State _state = State.Idle;
    private State _nextState = State.Idle;

    private Rigidbody _rb;
    private Rigidbody _targetrb;
    private Vector3 _playerPos;
    [SerializeField] private float _force = 400;
    [SerializeField] private float _speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody>();
        _playerPos = GetComponent<Transform>().position;
        IdleStart();
    }

    // Update is called once per frame
    void Update()
    {
        //現在のステートの処理
        switch (_state)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Movement:
                MovementUpdate();
                break;
            case State.Dead:
                DeadUpdate();
                break;
        }

        //ステートが切り替わったら
        if (_state != _nextState)
        {
            //終了処理を実行
            switch (_state)
            {
                case State.Idle:
                    IdleEnd();
                    break;
                case State.Movement:
                    MovementEnd();
                    break;
                case State.Dead:
                    DeadEnd();
                    break;
            }
            //次のステートに遷移
            _state = _nextState;
            switch (_state)
            {
                case State.Idle:
                    IdleStart();
                    break;
                case State.Movement:
                    MovementStart();
                    break;
                case State.Dead:
                    DeadStart();
                    break;
            }
        }
    }

    //ステートを遷移
    private void ChangeState(State nextState)
    {
        _nextState = nextState;
    }
    //-------------------------------------
    //IdleState管理
    private void IdleStart()
    {
        Debug.Log("IdleState開始");
    }
    private void IdleUpdate()
    {
        ChangeState(State.Movement);
    }
    private void IdleEnd()
    {
        Debug.Log("IdleState終了");
    }
    //-------------------------------------
    //MovementState管理
    private void MovementStart()
    {
        Debug.Log("MovementState開始");
    }
    private void MovementUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector3(x * _speed, 0, z * _speed);
        Vector3 _diff = transform.position - _playerPos;
        if (_diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(_diff);
        }
        _playerPos = transform.position;
    }
    private void MovementEnd()
    {
        Debug.Log("MovementState終了");
    }
    //-------------------------------------
    //DeadState管理
    private void DeadStart()
    {
        Debug.Log("DeadState開始");
    }
    private void DeadUpdate()
    {

    }
    private void DeadEnd()
    {
        Debug.Log("DeadState終了");
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            _targetrb = col.gameObject.GetComponent<Rigidbody>();

            Vector3 posA = transform.position;
            Vector3 posB = col.transform.position;
            Vector3 direction = (posB - posA).normalized;

            _targetrb.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
