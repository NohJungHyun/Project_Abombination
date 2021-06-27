using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState
{
    protected BattleController battleController;
    // protected BattleEventManager battleEventManager;

    // public static event BattleStateEventDelegate BattleStateEvent;
    // public EventBox stateEventBox;

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public BattleState(BattleController _battleController)
    {
        battleController = _battleController;
        // battleEventManager = _battleController.battleEventManager;
        // stateEventBox = BattleStateEventBoxes.instance.CallByString();
    }

    // public virtual void InvokeEventBox()
    // {
    //     stateEventBox.InvokeEventCollection();
    // }

    // public virtual void SetEventBox(EventBox _eb)
    // {
    //     stateEventBox = _eb;
    // }

    public virtual void SetEventBoxByString(string _s)
    {
        // stateEventBox = BattleEventManager.instance.battleStateEventBoxDictionary[_s];
    }
}
