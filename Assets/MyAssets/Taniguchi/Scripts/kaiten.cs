using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaiten : MonoBehaviour
{
    [SerializeField] private Vector3 _angleVelocity;
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += _angleVelocity *_speed* Time.deltaTime;
    }
}
