using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnEndState : BattleState
{
    public PlayerTurnEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        //stateEventBox = BombEventManager.battleStateEventBoxDictionary[this.ToString()];
    }

    public override void EnterState()
    {
        battleController.baseCharacterPos = Vector3.zero;

        Debug.Log("Player End Enter!");
        
        ExitState();
    }

    public override void UpdateState()
    {
        Debug.Log("Player End Update!");
    }

    public override void ExitState()
    {
        Debug.Log("Player End Exit!");
        // _BattleController.NextTurn();
    }
}