using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllManu : MonoBehaviour
{
    [SerializeField]
    private GameObject Image1;
    [SerializeField]
    private GameObject Image2;

    private bool triger;
    // Start is called before the first frame update
    void Start()
    {
        Image1.SetActive(true);
        Image2.SetActive(false);
        triger = true;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (triger)
        {
            if (Input.GetButtonDown("GamePad_Start"))
            {
                Image1.SetActive(false);
                Image2.SetActive(true);
                triger = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("GamePad_Start"))
            {
                Image2.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
}
