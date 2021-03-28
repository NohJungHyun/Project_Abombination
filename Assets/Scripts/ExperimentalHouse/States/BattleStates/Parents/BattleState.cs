using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleController battleController;
    public abstract void EnterState(BattleController _battleController);

    public abstract void UpdateState(BattleController _battleController);

    public abstract void ExitState(BattleController _battleController);

    public BattleState(BattleController _battleController)
    {
        battleController = _battleController;
    }
}
