using UnityEngine;
using System;

public abstract class BaseState<EState>where EState: Enum
{
    public BaseState(EState key)
    {
        StateKey = key;
    }
    public EState StateKey { get; private set; }
    /// <summary>
    /// 開始時に呼び出される関数
    /// </summary>
    public abstract void EnterState();
    /// <summary>
    /// Stateを抜けるときに呼び出される関数
    /// </summary>
    public abstract void ExitState();
    /// <summary>
    /// 呼び出されている間処理を行う関数
    /// </summary>
    public abstract void UpdateState();
    public abstract EState GetNextState();
    /// <summary>
    /// 当たり判定(触れたら)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerEnter(Collider other);
    /// <summary>
    /// 当たり判定(触れてる間)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerStay(Collider other);
    /// <summary>
    /// 当たり判定(抜けたら)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerExit(Collider other);
}
