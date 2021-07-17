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

    public abstract IEnumerator EnterState();
    public abstract IEnumerator UpdateState();
    public abstract IEnumerator ExitState();
}
