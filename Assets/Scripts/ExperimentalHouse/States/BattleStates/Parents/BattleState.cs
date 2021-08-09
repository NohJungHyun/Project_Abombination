using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : IState
{
    protected BattleController battleController;

    public BattleState(BattleController _battleController)
    {
        battleController = _battleController;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    
    public virtual void LateUpdateState(){ }
}
