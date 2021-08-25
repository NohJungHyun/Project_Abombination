using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_CharacterTurnEnd : BattleState
{
    public AI_CharacterTurnEnd(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("AI_CharacterTurnEnd Enter!");

        // battleController.SetState(new SelectActCharacter(battleController));
        // CharacterActionController.instance.SetState(new WaitingOrder(battleController));
        // battleController.SetState(new AI_SelectCharacter(battleController));

    }

    public override void UpdateState()
    {
        Debug.Log("AI_CharacterTurnEnd Update!");
    }

    public override void ExitState()
    {
        Debug.Log("AI_CharacterTurnEnd Exit!");
    }
}
