using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_CharacterTurnStart : BattleState
{
    public AI_CharacterTurnStart(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("AI_CharacterTurnStart Enter!");
        battleController.SetState(new AI_CharacterTurnDo(battleController));

        // battleController.SetState(new SelectActCharacter(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("AI_CharacterTurnStart Exit!");
    }
}
