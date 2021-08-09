using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : BattleState
{
    public RoundStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("Round Start Enter!");

        battleController.SetState(new SelectActCharacter(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("Round Start Exit!");
    }
}
