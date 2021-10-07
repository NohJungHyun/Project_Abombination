using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseStart : BattleState
{
    public PhaseStart(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("PhaseStart Enter!");

        if(BattleParticipantsManager.nowTurnParticipant.canControl)
            battleController.SetState(new SelectActCharacter(battleController));
        else
            battleController.SetState(new AI_SelectCharacter(battleController));        
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("PhaseStart Exit!");
    }
}
