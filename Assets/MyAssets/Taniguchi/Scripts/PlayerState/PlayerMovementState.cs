using UnityEngine;

public class PlayerMovementState : PlayerState
{
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
        float x = Input.GetAxis("Horizontal0");
        float z = Input.GetAxis("Vertical0");
        Context.myTransform.position += new Vector3(x, 0, z) * Context.pspeed * Time.deltaTime;
        Debug.Log("MovementStateíÜ");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return PlayerStateMachine.PlayerStates.Dead;
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
