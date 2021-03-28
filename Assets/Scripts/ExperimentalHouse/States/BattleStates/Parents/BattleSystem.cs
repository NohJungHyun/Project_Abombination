using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : BattleStateMachine
{
    
    public override void SetState(BattleState _battleState)
    {
        battleState = _battleState;
        // _battleState.EnterState(this);
        //throw new System.NotImplementedException();
    }
}
