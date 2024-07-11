using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class AudioBGM : MonoBehaviour
{
    private AudioSource audioSource;

    //ファイルパス
    private const string fPath = "Sound/BGM";

    //BGM音源配列
    [SerializeField] private AudioClip[] bgmClips;
    //音源番号　音源と名前共通
    private int bgmNumber;
    //音源の名前配列
    [SerializeField] private string[] bgmName;

    //BGMの音量
    [SerializeField]private float bgmVolume;

    //BFMTypeのテキスト
    [SerializeField] private TextMeshProUGUI bgmTypeText;
    //bgmの音量のテキスト
    [SerializeField] private TextMeshProUGUI bgmVolumeText;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        //初期音源設定
        bgmNumber = 0;
        //初期音量設定
        bgmVolume = 5;
       
        //音源を配列に読み込む
        InData(ref bgmClips, fPath);

        //名前配列の生成
        bgmName = new string[bgmClips.Length];
        //音源の名前を配列に読み込む
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgmName[i] = CutString(bgmClips[i].ToString(), ' ');
        }

        //BGM再生
        LoopPlayBack(bgmClips[bgmNumber]);
    }

    // Update is called once per frame
    void Update()
    {
        //音源の更新
        AudioUpdate(bgmClips[bgmNumber]);
        //音量設定
        audioSource.volume = (bgmVolume/10);

        //Text表示
        bgmVolumeText.text = bgmVolume.ToString();
        bgmTypeText.text = bgmName[bgmNumber];
    }
    //--------------------------------------------------------------------------------------
    //指定したフォルダ内のデータを配列に入れる
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
    //--------------------------------------------------------------------------------------
    //指定した音源をループ再生させる
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClipを設定する
        audioSource.clip = clip;

        //ループ再生を有効にする
        audioSource.loop = true;

        //BGMを再生する
        audioSource.Play();
    }
    //--------------------------------------------------------------------------------------
    //音源の更新
    private void AudioUpdate(AudioClip clip_)
    {
        //どの音源が再生されているかコピー
        AudioClip audioClipCopy = audioSource.clip;

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
    //プラスボタン　BGM音量
    public void VolumePlusButton()
    {
        if (bgmVolume == 10)
        {
            //上限だったらプラスしない
            return;
        }
        bgmVolume++;
    }
    //--------------------------------------------------------------------------------------
    //プラスボタン　BGMType
    public void TypePlusButton()
    {
        if (bgmNumber == bgmClips.Length - 1)
        {
            //上限だったらプラスしない
            return;
        }
        bgmNumber++;
    }
    //--------------------------------------------------------------------------------------
    //マイナスボタン　BGM音量
    public void VolumeMinusButton()
    {
        if (bgmVolume == 0)
        {
            //下限だったらプラスしない
            return;
        }
        bgmVolume--;
    }
    //--------------------------------------------------------------------------------------
    //マイナスボタン　BGMTypr
    public void TypeMinusButton()
    {
        if (bgmNumber == 0)
        {
            //下限だったらプラスしない
            return;
        }
        bgmNumber--;
    }
}
