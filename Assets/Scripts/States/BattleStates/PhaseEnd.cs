using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEnd : BattleState
{
    public PhaseEnd(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("PhaseEnd Enter!");

        if (BattleParticipantsManager.instance.battleParticipants.IndexOf(BattleParticipantsManager.nowTurnParticipant) == BattleParticipantsManager.instance.battleParticipants.Count - 1)
            battleController.SetState(new RoundStartState(battleController));
        else
            battleController.SetState(new PhaseStart(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("PhaseEnd Exit!");

        BattleParticipantsManager.instance.CallNextParticipant();
    }
}
