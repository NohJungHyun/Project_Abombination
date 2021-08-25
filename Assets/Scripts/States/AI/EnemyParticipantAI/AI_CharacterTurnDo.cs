using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_CharacterTurnDo : BattleState
{
    public AI_CharacterTurnDo(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("AI_CharacterTurnDo Enter!");
        CharacterActionController.instance.SetState(new AI_WaitingOrder(battleController));
        // battleController.SetState(new AI_CharacterTurnEnd(battleController));
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        Debug.Log("AI_CharacterTurnDo Exit!");
    }
}
