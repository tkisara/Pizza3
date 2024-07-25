using UnityEngine;

public class PSEStateContext
{
    //PSEStateMachineに追加した共有エリアのものを書く
    private AudioSource _as;
    private AudioClip[] _Seclips;

    //----------------------------------------------------------------------------------------------
    //上で書いたものを引数とメソッド内に書く
    public PSEStateContext(AudioSource audioSource, AudioClip[] seclips)
    {
        _as = audioSource;
        _Seclips = seclips;
    }

    //----------------------------------------------------------------------------------------------

    //上で書いたものを返す
    public AudioSource audioSource => _as;
    public AudioClip[] seclips => _Seclips;
}
