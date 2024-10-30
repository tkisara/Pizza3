using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    //シングルトンのインスタンス
    private static AudioDirector _instance;
    public static AudioDirector _Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioDirector>();
                if (_instance == null)
                {
                    GameObject _obj = new GameObject("AudioDirector");
                    _instance = _obj.AddComponent<AudioDirector>();
                    DontDestroyOnLoad(_obj);
                }
            }
            
            return _instance;
        }
    }

    //オーディオコンポネント　BGM
    private AudioSource _audioSource;
    //オーディオコンポネント　SE
    [SerializeField] private GameObject _audioSEObj;
    private AudioSource _audioSourceSE;

    [SerializeField] private AudioClip _seAudioClip;
    public AudioClip _bgmAudioClip;

    //BGMの音量
    public float _bgmVolume = 6;
    //SEの音量　全てのプレイヤが参照する
    public float _seVolume = 4;
    //bgm番号
    //[HideInInspector] public int _bgmNumber = 0;


    //スタートよりも早く処理する
    private void Awake()
    {

        //シングルトンのインスタンスを設定
        if (_instance == null)
        {
            //Debug.Log("AudioDirector instance is null, setting this instance.");
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != null)
        {
            //Debug.Log("AudioDirector instance already exists, destroying this instance.");
            Destroy(gameObject);
            //return;
        }

        //オーディオソースの初期化
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (_audioSEObj != null)
        {
            _audioSourceSE = _audioSEObj.GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //コンポネント取得
        _audioSource = GetComponent<AudioSource>();
        //音量設定
        _audioSource.volume = _bgmVolume / 10;
        _audioSourceSE.volume = _seVolume / 10;
        //初期BGM
        LoopPlayBack(_bgmAudioClip);
    }

    // Update is called once per frame
    void Update()
    {
        AudioUpdate(_bgmAudioClip);
        _audioSource.volume = _bgmVolume / 10;
        _audioSourceSE.volume = _seVolume / 10;
    }
    //--------------------------------------------------------------------------------------
    //指定した音源をループ再生させる
    public void LoopPlayBack(AudioClip clip)
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
    public void AudioUpdate(AudioClip clip_)
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
    //SE音量確認ボタン
    public void SETestButton()
    {
        _audioSourceSE.PlayOneShot(_seAudioClip);
    }
}
