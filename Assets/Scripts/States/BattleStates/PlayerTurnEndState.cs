using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnEndState : BattleState
{
    NowTurnCharacterManager nowTurnCharacterManager;
    BattleParticipantsManager battleParticipantsManager;

    public PlayerTurnEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        //stateEventBox = BombEventManager.battleStateEventBoxDictionary[this.ToString()];
    }

    public override void EnterState()
    {
        nowTurnCharacterManager.baseCharacterPos = Vector3.zero;

        Debug.Log("Player End Enter!");

        nowTurnCharacterManager.GetNowCharacter().CharacterMoveAreaController.BackToCharacter();
        nowTurnCharacterManager.GetNowCharacter().CharacterMoveAreaController.TurnOnMoveAreaMesh(false);
        nowTurnCharacterManager.SetNowCharacter(null);

        battleController.SetState(new SelectActCharacter(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("Player End Exit!");

    }
}