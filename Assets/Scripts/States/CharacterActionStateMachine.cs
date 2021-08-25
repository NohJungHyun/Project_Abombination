using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionStateMachine : StateMachine
{
    protected CharacterAction state;
    // Coroutine characterActionCoroutine;

    public override void SetState(IState _state)
    {
        
        if(state != null)
            state.ExitState();

        state = (CharacterAction)_state;

        if(state != null)
            state.EnterState();
        
    }

    public override void ResetState()
    {
        state = null;
    }

    public override IState GetState()
    {
        return state;
    }
}
