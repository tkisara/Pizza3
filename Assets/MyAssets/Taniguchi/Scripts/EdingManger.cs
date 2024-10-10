using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EdingManger : MonoBehaviour
{
    private string _tag;
    [SerializeField] private Object PlayerObj1;
    [SerializeField] private Object PlayerObj2;
    [SerializeField] private Object PlayerObj3;
    [SerializeField] private Object PlayerObj4;
    [SerializeField] private Text _winText;
    // Start is called before the first frame update
    private void Awake()
    {
        _tag = PlayerPrefs.GetString("tag","Player");
        Debug.Log("éÛÇØéÊÇ¡ÇΩ");
    }
    void Start()
    {
        switch (_tag)
        {
            case "Player1(Clone)":
                Instantiate(PlayerObj1, this.transform.position, Quaternion.identity);
                _winText.text = "Player1 Win";
                Debug.Log("çÏÇ¡ÇΩ");
                break;
            case "Player2(Clone)":
                Instantiate(PlayerObj2, this.transform.position, Quaternion.identity);
                _winText.text = "Player2 Win";
                Debug.Log("çÏÇ¡ÇΩ");
                break;
            case "Player3(Clone)":
                Instantiate(PlayerObj3, this.transform.position, Quaternion.identity);
                _winText.text = "Player3 Win";
                Debug.Log("çÏÇ¡ÇΩ");
                break;
            case "Player4(Clone)":
                Instantiate(PlayerObj4, this.transform.position, Quaternion.identity);
                _winText.text = "Player4 Win";
                Debug.Log("çÏÇ¡ÇΩ");
                break;
            default:
                Debug.Log("çÏÇÁÇ»Ç©Ç¡ÇΩ");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetButtonDown("GamePad_Entrer"))
        {
            SceneManager.LoadScene("Titel");
        }
    }
}
