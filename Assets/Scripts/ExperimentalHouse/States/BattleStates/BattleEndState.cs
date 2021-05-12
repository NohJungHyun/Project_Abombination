using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndState : BattleState
{
    public BattleEndState(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        // stateEventBox = BombEventManager.instance.battleStateEventBoxDictionary["BattleEnd"];
        //stateEventBox = BombEventManager.battleStateEventBoxDictionary["BattleEnd"];
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {

    }
}
