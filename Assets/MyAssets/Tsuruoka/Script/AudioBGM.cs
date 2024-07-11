using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    private AudioSource audioSource;

    //BGM音源
    [SerializeField]private AudioClip[] bgmClips;

    private string fPath = "Sound/BGM";

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        //音源を読み込む
        InData(fPath);

        //BGM再生
        LoopPlayBack(bgmClips[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //--------------------------------------------------------------------------------------
    //指定したフォルダ内のデータを配列に入れる
    private void InData(string s)
    {
        bgmClips = Resources.LoadAll<AudioClip>(s);
    }
    //--------------------------------------------------------------------------------------
    //ループ再生
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClipを設定する
        audioSource.clip = clip;

        //ループ再生を有効にする
        audioSource.loop = true;

        //BGMを再生する
        audioSource.Play();
    }
}
