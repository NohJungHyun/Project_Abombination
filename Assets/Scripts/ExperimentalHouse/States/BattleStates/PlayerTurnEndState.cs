using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnEndState : BattleState
{
    public PlayerTurnEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Player End Enter!");
        ExitState(_BattleController);
    }

    public override void UpdateState(BattleController _BattleController)
    {
        Debug.Log("Player End Update!");
    }

    public override void ExitState(BattleController _BattleController)
    {
        Debug.Log("Player End Exit!");
        _BattleController.NextTurn();
    }
}