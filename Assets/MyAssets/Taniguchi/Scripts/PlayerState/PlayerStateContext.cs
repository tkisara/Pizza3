using UnityEngine;

public class PlayerStateContext
{
    private Rigidbody _rb;
    private Collider _col;

    public PlayerStateContext(Rigidbody rb,Collider col)
    {
        _rb = rb;
        _col = col;
    }
    public Rigidbody rb => _rb;
    public Collider col => _col;
}
