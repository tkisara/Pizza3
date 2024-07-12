using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class AudioManeger : MonoBehaviour
{
    //シングルトンのインスタンス
    private static AudioManeger _instance;
    public static AudioManeger _Instance
    {
        get
        {
            if(_instance == null)
            {
                //オーディオマネージャーが存在しない場合は新しく作成
                GameObject _obj = new GameObject("AudioManeger");
                _instance = _obj.AddComponent<AudioManeger>();
                DontDestroyOnLoad(_obj);
            }
            return _instance;
        }
    }

    //オーディオコンポネント
    private AudioSource _audioSource;

    //スタートよりも早く処理する
    private void Awake()
    {

        //シングルトンのインスタンスを設定
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //オーディオソースの初期化
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    //ファイルパス　BGM
    private const string _fPath = "Sound/BGM";

    //BGM入れる配列
    [SerializeField] private AudioClip[] _bgmClips;
    //BGMの名前を入れる配列
    [SerializeField] private string[] _bgmName;
    //配列番号　BGM配列と名前配列で共通
    private int _bgmNumber;

    //BGMの音量
    private float _bgmVolume;
    //SEの音量　全てのプレイヤが参照する
    public float _seVolume;

    //BGMの種類を表示するText
    [SerializeField] private TextMeshProUGUI _bgmTypeText;
    //BGMの音量を表示するText
    [SerializeField] private TextMeshProUGUI _bgmVolumeText;
    //SEの音量を表示するText
    [SerializeField] private TextMeshProUGUI _seVolumeText;

    //イベントシステム
    private EventSystem _eventSystem;
    //サウンド設定UI　Canvas
    [SerializeField] private Canvas _audioSettingCanvas;
    //サウンド設定UIで最初に選択されているボタン
    [SerializeField] private GameObject _firstB;

    // Start is called before the first frame update
    void Start()
    {
        //コンポネント取得
        _audioSource = GetComponent<AudioSource>();
        //イベントシステムのインスタンス生成
        _eventSystem = EventSystem.current;

        //サウンド設定UIを非表示にする
        _audioSettingCanvas.enabled = false;
        //最初に再生されるBGMの設定
        _bgmNumber = 0;
        //音量設定
        _bgmVolume = 5;
        _seVolume = 5;

        //BGM配列の設定
        InData(ref  _bgmClips, _fPath);
        //名前配列の設定
        _bgmName = new string[_bgmClips.Length];
        for (int i = 0; i < _bgmClips.Length; i++)
        {
            _bgmName[i] = CutString(_bgmClips[i].ToString(), ' ');
        }

        //BGM再生
        LoopPlayBack(_bgmClips[_bgmNumber]);
    }

    // Update is called once per frame
    void Update()
    {
        //BGMの更新
        AudioUpdate(_bgmClips[_bgmNumber]);
        //BGMの音量設定
        _audioSource.volume = (_bgmVolume / 10);

        //Text表示
        _bgmVolumeText.text = _bgmVolume.ToString();
        _bgmTypeText.text = _bgmName[_bgmNumber];

        //動作確認のための処理
        //後で必ず消す
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                OpenUI();
            }
        }
        //
    }
    //--------------------------------------------------------------
    //指定したフォルダ内の音源を配列に入れる
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
    //--------------------------------------------------------------------------------------
    //指定した音源をループ再生させる
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClipを設定する
        _audioSource.clip = clip;

        //ループ再生を有効にする
        _audioSource.loop = true;

        //BGMを再生する
        _audioSource.Play();
    }
    //--------------------------------------------------------------------------------------
    //音源の更新
    private void AudioUpdate(AudioClip clip_)
    {
        //どの音源が再生されているかコピー
        AudioClip audioClipCopy = _audioSource.clip;

        if (audioClipCopy == clip_)
        {
            return;
        }
        else
        {
            LoopPlayBack(clip_);
        }
    }
    //--------------------------------------------------------------------------------------
    //特定の文字で区切る
    private string CutString(string s_, char delimiter_)
    {
        //元の文字列をコピー
        string subString = s_;
        // 特定の文字の位置を検索
        int delimiterIndex = subString.IndexOf(delimiter_);
        // 特定の文字より前の部分文字列を取得
        subString = subString.Substring(0, delimiterIndex);
        return subString;
    }
    //--------------------------------------------------------------------------------------
    //サウンド設定UIを開く
    public void OpenUI()
    {
        //表示
        _audioSettingCanvas.enabled = true;
        //初期ボタンの設定
        _eventSystem.SetSelectedGameObject(_firstB);
    }
    //--------------------------------------------------------------------------------------
    //閉じるボタン
    public void CloseButton()
    {
        //サウンド設定UIを閉じる
        _audioSettingCanvas.enabled = false;
    }
    //--------------------------------------------------------------------------------------
    //プラスボタン　BGM音量
    public void BGMVolumePlusButton()
    {
        if (_bgmVolume == 10)
        {
            //上限だったらプラスしない
            return;
        }
        _bgmVolume++;
    }
    //--------------------------------------------------------------------------------------
    //プラスボタン　SE音量
    public void SEVolumePlusButton()
    {
        if (_seVolume == 10)
        {
            //上限だったらプラスしない
            return;
        }
        _seVolume++;
    }
    //--------------------------------------------------------------------------------------
    //プラスボタン　BGMType
    public void BGMTypePlusButton()
    {
        if (_bgmNumber == _bgmClips.Length - 1)
        {
            //上限だったら０にする　選択肢をループさせるため
            _bgmNumber = 0;
            return;
        }
        _bgmNumber++;
    }
    //--------------------------------------------------------------------------------------
    //マイナスボタン　BGM音量
    public void BGMVolumeMinusButton()
    {
        if (_bgmVolume == 0)
        {
            //下限だったらプラスしない
            return;
        }
        _bgmVolume--;
    }
    //--------------------------------------------------------------------------------------
    //マイナスボタン　SE音量
    public void SEVolumeMinusButton()
    {
        if (_seVolume == 0)
        {
            //下限だったらプラスしない
            return;
        }
        _seVolume--;
    }
    //--------------------------------------------------------------------------------------
    //マイナスボタン　BGMType
    public void BGMTypeMinusButton()
    {
        if (_bgmNumber == 0)
        {
            //下限だったらBGM配列の最後尾の番号を入れる　選択肢をループさせるため
            _bgmNumber = _bgmClips.Length - 1;
            return;
        }
        _bgmNumber--;
    }
}
