using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : BattleState
{
    BattleParticipantsManager participantsManager = BattleParticipantsManager.instance;

    public RoundStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("Round Start Enter!");
        battleController.SetState(null);
        CharacterActionController.instance.SetState(null);
        NowTurnCharacterManager.nowPlayCharacter = null;

        for(int p = 0; p < participantsManager.battleParticipants.Count; p++)
            participantsManager.battleParticipants[p].Init();

        if(BattleParticipantsManager.nowTurnParticipant == null)
            BattleParticipantsManager.nowTurnParticipant = BattleParticipantsManager.instance.battleParticipants[0];

        battleController.SetState(new PhaseStart(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("Round Start Exit!");
    }
}
