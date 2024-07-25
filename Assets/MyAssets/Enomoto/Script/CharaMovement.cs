using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float Speed = 1;

    [SerializeField]
    int PlayerNo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ˆÚ“®
        float x = Input.GetAxisRaw("Horizontal" + PlayerNo);
        float z = Input.GetAxisRaw("Vertical" + PlayerNo);
        transform.position += new Vector3(x,0,z) * Speed * Time.deltaTime;

        //ƒWƒƒƒ“ƒv

       
    }
}
