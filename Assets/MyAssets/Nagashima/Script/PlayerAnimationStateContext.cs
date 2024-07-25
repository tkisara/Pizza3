using UnityEngine;

public class PlayerAnimationStateContext
{
    private Rigidbody _rb;
    private Collider _col;
    private Animator _animator;

    public PlayerAnimationStateContext(Rigidbody rb, Collider col, Animator animator)
    {
        _rb = rb;
        _col = col;
        _animator = animator;

    }
    public Rigidbody rb => _rb;
    public Collider col => _col;
    public Animator animator => _animator;

}
