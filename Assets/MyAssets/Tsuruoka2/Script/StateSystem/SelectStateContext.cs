using System.Collections.Generic;
using UnityEngine;

public class SelectStateContext
{
    //SelectStateMachineに追加した共有エリアのものを書く
    private int _canvasNumber = 0; //セレクト画面番号
    private int _playerNum; //プレイ人数
    private int _playerModel; //キャラクタモデル番号
    private int _bgmType; //BGM番号
    private int _bgmVolume; //BGM音量
    private int _seVolume; //SE音量
    private List<Canvas> _canvass; //セレクト画面のcanvas
    //----------------------------------------------------------------------------------------------
    //上で書いたものを引数とメソッド内に書く
    public SelectStateContext(int canvasNumber, int playerNum, int playerModel, int bgmType, int bgmVolume, int seVolume, List<Canvas> canvass)
    {
        _canvasNumber = canvasNumber;
        _playerNum = playerNum;
        _playerModel = playerModel;
        _bgmType = bgmType;
        _bgmVolume = bgmVolume;
        _seVolume = seVolume;
        _canvass = canvass;
    }

    //----------------------------------------------------------------------------------------------
    //上で書いたものを返す
    public int canvasNumber => _canvasNumber;
    public int playerNum => _playerNum;
    public int playerModel => _playerModel;
    public int bgmType => _bgmType;
    public int bgmVolume => _bgmVolume;
    public int seVolume => _seVolume;
    public List<Canvas> canvass => _canvass;

}
