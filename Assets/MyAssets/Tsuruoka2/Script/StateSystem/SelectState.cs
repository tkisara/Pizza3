using UnityEngine;

public abstract class SelectState : BaseState<SelectStateMachine.SelectStates>
{
    protected SelectStateContext Context;

    //----------------------------------------------------------------------------------------------
    public SelectState(SelectStateContext context, SelectStateMachine.SelectStates statekey) : base(statekey)
    {
        Context = context;
    }
}
