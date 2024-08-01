using UnityEngine;

public class PlayerMovementState : PlayerState
{
    float x;
    float z;
    public PlayerMovementState(PlayerStateContext context, PlayerStateMachine.PlayerStates estate) : base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        
        Debug.Log("MovementStateäJén");
    }

    public override void ExitState()
    {
        Debug.Log("MovementStateèIóπ");
    }

    public override void UpdateState()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Context.myTransform.position += new Vector3(x, 0, z) * Context.pspeed * Time.deltaTime;
        Debug.Log("MovementStateíÜ");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        if (x==0&&z==0)
        {
            Debug.Log("âüÇ≥ÇÍÇƒÇ»Ç¢ÇÊ");
            //return PlayerStateMachine.PlayerStates.Idle;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        Rigidbody _other = other.GetComponent<Rigidbody>();
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("ìñÇΩÇ¡ÇΩ");
            _other.AddForce(new Vector3(100, 10, 0),ForceMode.Impulse);
        }
        
    }

    public override void OnTriggerStay(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }
}
