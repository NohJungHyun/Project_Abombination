using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleSystem battleSystem;
    public abstract void EnterState(BattleSystem _battleSystem);

    public abstract void UpdateState(BattleSystem _battleSystem);

    public abstract void ExitState(BattleSystem _battleSystem);

    public BattleState(BattleSystem _battleSystem)
    {
        battleSystem = _battleSystem;
    }
}
