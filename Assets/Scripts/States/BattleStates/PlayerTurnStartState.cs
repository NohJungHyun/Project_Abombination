using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStartState : BattleState
{

    CameraController cameraController;
    NowTurnCharacterManager nowTurnCharacterManager;

    public PlayerTurnStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        cameraController = _battleController.cameraController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
    }

    public override void EnterState()
    {
        Debug.Log("Player Start Enter!");

        BattleOccurrenceContainer.instance.InvokeContainer(9);

        nowTurnCharacterManager.GetNowCharacter().CharacterMoveAreaController.Reset();
        nowTurnCharacterManager.ResetCharacterPos();
        cameraController.SetZoomingCharacter(nowTurnCharacterManager.GetNowCharacterTransform());

        battleController.SetState(new PlayerTurnDoState(battleController));

    }

    public override void UpdateState()
    {
        Debug.Log("Player Start Update!");
    }

    public override void ExitState()
    {
        Debug.Log("Player Start Exit!");
    }

}