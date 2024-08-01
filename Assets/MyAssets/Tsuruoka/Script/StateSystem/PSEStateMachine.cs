using UnityEngine;
using UnityEngine.Assertions;

public class PSEStateMachine : StateManager<PSEStateMachine.PSEStates>
{
    /// <summary>
    /// PSEStateMachineで扱うStateの種類
    /// <summary>
    public enum PSEStates
    {
        Idel,
        Movement,
        Jump,
        Dead,
    }

    private PSEStateContext _context;
    private float __volume = 0; //音量
    private const string _fPath = "Sound/SE/Player";

    //共有エリア　contextに入れる
    //
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip[] _Seclips; //SE音源配列
    //

    //----------------------------------------------------------------------------------------------
    void Awake()
    {
        //エラーメッセージ表示
        NullMessage();
        //共有エリアに追加したものを引数に持たせる
        _context = new PSEStateContext(_as, _Seclips);

        InitializeStates();

        //音量設定
        UpdateVolume();
        //SEの読み込み
        InData(ref _Seclips, _fPath);
    }
    //----------------------------------------------------------------------------------------------
    private void NullMessage()
    {
        Assert.IsNotNull(_as, "nullです");
    }
    //----------------------------------------------------------------------------------------------
    // PSEStateMachineで使うStateの初期化と最初に呼び出されるStateの指定
    private void InitializeStates()
    {
        //追加したState
        States.Add(PSEStates.Idel, new PSEIdelState(_context, PSEStates.Idel));
        States.Add(PSEStates.Movement, new PSEMovementState(_context, PSEStates.Movement));
        States.Add(PSEStates.Jump, new PSEJumpState(_context, PSEStates.Jump));
        States.Add(PSEStates.Dead, new PSEDeadState(_context, PSEStates.Dead));

        //最初に呼び出すState
        CurrentState = States[PSEStates.Idel];
    }
    //----------------------------------------------------------------------------------------------
    //追加メソッドはここに書く
    //----------------------------------------------------------------------------------------------
    //Update()が終了したときに呼び出される
    private void LateUpdate()
    {
        UpdateVolume();
    }
    //----------------------------------------------------------------------------------------------
    //音量の更新
    public void UpdateVolume()
    {
        float seVolume = AudioManeger._Instance._seVolume;
        //float seVolume = 1;
        if (__volume != seVolume)
        {
            //変更あり
            __volume = seVolume;
            _as.volume = __volume / 10f;
        }
    }
    //----------------------------------------------------------------------------------------------
    //SEの読み込み
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
}
