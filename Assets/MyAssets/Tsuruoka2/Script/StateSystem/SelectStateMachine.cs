using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static PSEStateMachine;

public class SelectStateMachine : StateManager<SelectStateMachine.SelectStates>
{
    /// <summary>
    /// SelectStateMachineで扱うStateの種類
    /// <summary>
    public enum SelectStates
    {
        None,
        PlayerNum,   //プレイ人数
        PlayerModel, //操作するキャラクタ
        BGMType,     //BGMの種類
        Volume,      //音量
    }

    private SelectStateContext _context;

    //共有エリア　contextに入れる
    //
    private int _canvasNumber = 0; //セレクト画面番号
    private int _playerNum = 1; //プレイ人数
    private int _playerModel = 0; //キャラクタモデル番号
    private int _bgmType = 0; //BGM番号
    private int _bgmVolume = 10; //BGM音量
    private int _seVolume = 10; //SE音量
    [SerializeField] private List<Canvas> _canvass; //セレクト画面のcanvas
    //

    //----------------------------------------------------------------------------------------------
    void Awake()
    {
        //エラーメッセージ表示
        NullMessage();
        //共有エリアに追加したものを引数に持たせる
        _context = new SelectStateContext(_canvasNumber, _playerNum, _playerModel, _bgmType, _bgmVolume, _seVolume, _canvass);

        InitializeStates();

    }
    //----------------------------------------------------------------------------------------------
    private void NullMessage()
    {
        Assert.IsNotNull("nullです");
    }
    //----------------------------------------------------------------------------------------------
    // SelectStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        //全てのセレクト画面を非表示にする
        for (int i = 0; i < _canvass.Count; i++)
        {
            _canvass[i].gameObject.SetActive(false);
        }
        //追加したState
        States.Add(SelectStates.None, new SelectNoneState(_context, SelectStates.None));
        States.Add(SelectStates.PlayerNum, new SelectPlayerNumState(_context, SelectStates.PlayerNum));
        States.Add(SelectStates.PlayerModel, new SelectPlayerModelState(_context, SelectStates.PlayerModel));
        States.Add(SelectStates.BGMType, new SelectBGMTypeState(_context, SelectStates.BGMType));
        States.Add(SelectStates.Volume, new SelectVolumeState(_context, SelectStates.Volume));
        //最初に呼び出すState
        CurrentState = States[SelectStates.None];
    }
    //----------------------------------------------------------------------------------------------
    //追加メソッドはここに書く
    //----------------------------------------------------------------------------------------------

}
