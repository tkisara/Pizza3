using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChenge : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetActive_OF();
    }

    void SetActive_OF()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_camera.activeInHierarchy)
            {
                _camera.SetActive(false);
            }
            else
            {
                _camera.SetActive(true);
            }
        }
    }
}
