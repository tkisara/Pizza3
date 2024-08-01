using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdingManger : MonoBehaviour
{
    [SerializeField] private int _num;
    [SerializeField] private Object PlayerObj1;
    [SerializeField] private Object PlayerObj2;
    [SerializeField] private Object PlayerObj3;
    [SerializeField] private Object PlayerObj4;
    // Start is called before the first frame update
    void Start()
    {
        switch (_num)
        {
            case 1:
                Instantiate(PlayerObj1, this.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(PlayerObj2, this.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(PlayerObj3, this.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(PlayerObj4, this.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
