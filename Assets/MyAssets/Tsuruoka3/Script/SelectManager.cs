using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    //選択画面の状態
    private enum SelectState
    {
        PlayerNum, //プレイ人数選択
        Audio, //オーディオ設定

    }

    private SelectState state;
    [SerializeField] private List<Dropdown> dropdowns; //プルダウンコンポーネント
    [SerializeField] private List<AudioClip> audioClips; //BGMリスト
    private int bgmTypeNumber;

    //共有変数
    public int PlayerNum; //プレイ人数
    public AudioClip audioClip; //再生するBGM
    public int bgmVolume;
    public int seVolume;

    // Start is called before the first frame update
    void Start()
    {
        state = SelectState.PlayerNum;
        audioClip = audioClips[0];
        bgmVolume = 6;
        seVolume = 6;
        bgmTypeNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case SelectState.PlayerNum: //プレイ人数選択画面
                PlayerNum = dropdowns[0].value + 1;
                break;
            case SelectState.Audio: //オーディオ設定
                bgmTypeNumber = dropdowns[1].value;
                audioClip = audioClips[bgmTypeNumber];
                break;
            default:
                break;
        }
    }
}
