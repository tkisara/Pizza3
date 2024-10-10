using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    
    //選択画面の状態
    private enum SelectState
    {
        Ready, //準備
        PlayerNum, //プレイ人数選択
        Audio, //オーディオ設定
        Go, //設定完了、ゲーム画面に移動する
    }

    private SelectState state;
    [SerializeField] private List<Canvas> canvass; //セレクト画面リスト
    [SerializeField] private List<Dropdown> dropdowns; //プルダウンコンポーネント
    [SerializeField] private List<AudioClip> audioClips; //BGMリスト
    private int bgmTypeNumber; //BGM番号

    [SerializeField] private List<GameObject> buttons;
    private EventSystem eventSystem;

    //共有変数
    public static SelectManager Instance;

    [System.Serializable]
    public struct UserSetting
    {
        public int PlayerNum; // プレイ人数
        public AudioClip audioClip; // 再生するBGM
        public int bgmVolume;
        public int seVolume;
    }
    public UserSetting userSetting;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ゲーム開始時に PlayerNum を保存
    public void SavePlayerNum()
    {
        PlayerPrefs.SetInt("PlayerNum", userSetting.PlayerNum);
    }

    // ゲームシーンで PlayerNum を取得
    public void LoadPlayerNum()
    {
        userSetting.PlayerNum = PlayerPrefs.GetInt("PlayerNum", 1);  // デフォルトは1
    }


// Start is called before the first frame update
void Start()
    {
        eventSystem = EventSystem.current;

        //全てのセレクト画面を非表示
        for (int i = 0; i < canvass.Count; i++)
        {
            canvass[i].gameObject.SetActive(false);
        }
        //初期セレクト画面
        state = SelectState.Ready;

        bgmTypeNumber = 0;
        userSetting.audioClip = audioClips[bgmTypeNumber];
        userSetting.bgmVolume = 3 * 2;
        userSetting.seVolume = 2 * 2;

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case SelectState.Ready: //準備
                canvass[0].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[0]); //初期選択
                break;
            case SelectState.PlayerNum: //プレイ人数選択画面
                canvass[1].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[1]); //初期選択
                userSetting.PlayerNum = dropdowns[0].value + 1;
                break;
            case SelectState.Audio: //オーディオ設定
                canvass[2].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[2]); //初期選択
                bgmTypeNumber = dropdowns[1].value;
                userSetting.audioClip = audioClips[bgmTypeNumber];
                userSetting.bgmVolume = dropdowns[2].value * 2;
                userSetting.seVolume = dropdowns[3].value * 2;

                //各設定の引継ぎ
                AudioDirector._Instance._bgmAudioClip = userSetting.audioClip;
                AudioDirector._Instance._bgmVolume = userSetting.bgmVolume;
                AudioDirector._Instance._seVolume = userSetting.seVolume;
                break;
            case SelectState.Go:
                canvass[3].gameObject.SetActive(true);
                break;
            default:
                break;
        }

        if (Input.GetButtonDown("GamePad_Start"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    //OKボタン
    public void OnOKButton()
    {
        if (state == SelectState.Ready)
        {
            canvass[0].gameObject.SetActive(false); //非表示
            state = SelectState.PlayerNum; //次のセレクト画面に移動
        }
        else if (state == SelectState.PlayerNum)
        {
            canvass[1].gameObject.SetActive(false); //非表示
            dropdowns[2].value = 3;
            dropdowns[3].value = 2;
            state = SelectState.Audio; //次のセレクト画面に移動
        }
        else if (state == SelectState.Audio)
        {
            canvass[2].gameObject.SetActive(false); //非表示
            state = SelectState.Go; //次のセレクト画面に移動
        }
        else
        {
            canvass[3].gameObject.SetActive(false); //非表示
        }
    }

}
