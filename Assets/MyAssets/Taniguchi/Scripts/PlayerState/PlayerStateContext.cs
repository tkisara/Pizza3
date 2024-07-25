using UnityEngine;

public class PlayerStateContext
{
    private Rigidbody _rb;
    private Collider _col;
    private Transform _myTransform;
    private Object _enemyObject;
    private float _pSpeed;

    public PlayerStateContext(Rigidbody rb,Collider col, float pSpeed, Transform mytransform, Object enemyObject)
    {
        _rb = rb;
        _col = col;
        _pSpeed = pSpeed;
        _enemyObject = enemyObject;
        _myTransform = mytransform;
    }
    public Rigidbody rb => _rb;
    public Collider col => _col;
    public Object enemyObject => _enemyObject;
    public Transform myTransform => _myTransform;
    public float pspeed => _pSpeed;
}
