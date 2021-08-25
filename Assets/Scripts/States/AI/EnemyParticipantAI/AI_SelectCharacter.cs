﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SelectCharacter : BattleState
{
    public AI_SelectCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("AI_SelectCharacter Enter!");
        Temp_Character t = SelectRandomCharacter();

        if (BattleParticipantsManager.nowTurnParticipant.curCommandPoint >= t.GetCharacterInfo().needCommandPoint)
        {
            NowTurnCharacterManager.nowPlayCharacter = t;
            Debug.Log(t.name);
            battleController.SetState(new AI_CharacterTurnStart(battleController));
        }
        else
            battleController.SetState(new PhaseEnd(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("AI_SelectCharacter Exit!");
    }

    public Temp_Character SelectRandomCharacter()
    {
        int rand = Random.Range(0, BattleParticipantsManager.nowTurnParticipant.haveCharacters.Count);
        
        return BattleParticipantsManager.nowTurnParticipant.haveCharacters[rand];
    }
}