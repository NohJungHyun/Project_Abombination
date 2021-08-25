using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleStateMachine : StateMachine
{
    protected BattleState state;
    // Coroutine runningCoroutine;

    public override void SetState(IState _state)
    {
        if(state != null)
            state.ExitState();
        
        state = (BattleState)_state;
        
        if(state != null)
            state.EnterState();
        // if (state != null)
        // {
        //     if(runningCoroutine != null)
        //         StopCoroutine(runningCoroutine);
                
        //     print("Update멈춰!");
        //     StartCoroutine(state.ExitState());
        // }

        // state = (BattleState)_state;

        // if (state != null)
        // {
        //     StartCoroutine(state.EnterState());
        //     runningCoroutine = StartCoroutine(state.UpdateState());
        // }
    }

    public override void ResetState()
    {
        state = null;
    }
}
