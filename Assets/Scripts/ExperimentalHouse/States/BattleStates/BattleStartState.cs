using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(BattleController _battleController) : base(_battleController)
    {

    }

    public override void EnterState()
    {
        Debug.Log("Battle Start Enter!");
        battleController.SetState(new RoundStartState(battleController));
        
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        
    }
}
