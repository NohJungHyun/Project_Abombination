using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLoseState : BattleState
{
    public BattleLoseState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        // SetEventBoxByString("BattleLose");
        // BattleStateEventBoxes.instance.CallByString("BattleLose");
        
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
