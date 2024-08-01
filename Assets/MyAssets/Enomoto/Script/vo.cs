using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vo : MonoBehaviour
{
    private static object _instance;
    // Start is called before the first frame update
    private void Awake()
    {

        //シングルトンのインスタンスを設定
        if (_instance == null)
        {
            //Debug.Log("AudioManager instance is null, setting this instance.");
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
