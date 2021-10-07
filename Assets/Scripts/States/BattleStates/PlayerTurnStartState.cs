using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStartState : BattleState
{

    CameraController cameraController;
    NowTurnCharacterManager nowTurnCharacterManager;
    CharacterActionController characterActionController;

    public PlayerTurnStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        cameraController = _battleController.cameraController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        characterActionController = CharacterActionController.instance;
    }

    public override void EnterState()
    {
        Debug.Log("Player Start Enter!");
        // MoveReady();

        BattleOccurrenceContainer.instance.InvokeContainer(9);

        nowTurnCharacterManager.ResetCharacterPos();
        cameraController.SetZoomingCharacter(nowTurnCharacterManager.GetNowCharacterTransform());
        // characterActionController.SetState(new WaitingOrder(battleController));

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