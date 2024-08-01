using UnityEngine;

public abstract class PSEState : BaseState<PSEStateMachine.PSEStates>
{
    protected PSEStateContext Context;

    //----------------------------------------------------------------------------------------------
    public PSEState(PSEStateContext context, PSEStateMachine.PSEStates statekey) : base(statekey)
    {
        Context = context;
    }
}
