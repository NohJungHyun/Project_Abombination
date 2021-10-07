using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : BattleState
{
    public RoundEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        for(int i = 0; i < BattleParticipantsManager.instance.battleParticipants.Count; i++)
        {
            if(BattleParticipantsManager.instance.battleParticipants[i].allCharacterDie())
                battleController.SetState(new BattleEndState(battleController));
            else
                battleController.SetState(new RoundStartState(battleController));
        }
        
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        
    }
}