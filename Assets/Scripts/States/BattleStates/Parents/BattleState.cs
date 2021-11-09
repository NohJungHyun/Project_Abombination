using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : IState //OccurrenceContainer
{
    protected BattleController battleController;

    protected AlarmBattleStateSwitch alarm;

    public BattleState(BattleController _battleController)
    {
        battleController = _battleController;
        alarm = GameObject.FindObjectOfType<AlarmBattleStateSwitch>();
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public virtual void LateUpdateState() { }
}
