using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllManu : MonoBehaviour
{
    [SerializeField]
    private GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GamePad_Start"))
        {
            Image.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
