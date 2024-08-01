using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EdingManger : MonoBehaviour
{
    private string _tag;
    [SerializeField] private Object PlayerObj1;
    [SerializeField] private Object PlayerObj2;
    [SerializeField] private Object PlayerObj3;
    [SerializeField] private Object PlayerObj4;
    bool _is=true;
    // Start is called before the first frame update
    private void Awake()
    {
        _tag = PlayerPrefs.GetString("tag","Player");
        Debug.Log("éÛÇØéÊÇ¡ÇΩ");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_is)
        {
            switch (_tag)
            {
                case "Player1":
                    Instantiate(PlayerObj1, this.transform.position, Quaternion.identity);
                    Debug.Log("çÏÇ¡ÇΩ");
                    _is = false;
                    break;
                case "Player2":
                    Instantiate(PlayerObj2, this.transform.position, Quaternion.identity);
                    Debug.Log("çÏÇ¡ÇΩ");
                    _is = false;
                    break;
                case "Player3":
                    Instantiate(PlayerObj3, this.transform.position, Quaternion.identity);
                    Debug.Log("çÏÇ¡ÇΩ");
                    _is = false;
                    break;
                case "Player4":
                    Instantiate(PlayerObj4, this.transform.position, Quaternion.identity);
                    Debug.Log("çÏÇ¡ÇΩ");
                    _is = false;
                    break;
                default:
                    Debug.Log("çÏÇÁÇ»Ç©Ç¡ÇΩ");
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Titel");
        }
    }
}
