using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStartState : BattleState
{

    CameraController cameraController;

    public PlayerTurnStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        cameraController = _battleController.cameraController;
    }

    public override void EnterState()
    {
        Debug.Log("Player Start Enter!");
        // MoveReady();

        battleController.baseCharacterPos = battleController.GetNowCharacterPos();
        cameraController.SetZoomingCharacter(battleController.GetNowPlayCharacter().transform);
        battleController.SetCharacterAction(new WaitingOrder(battleController));
        //battleController.cameraController.SetZoomCondition(true);
        battleController.SetState(new PlayerTurnDoState(battleController));
    }

    public override void UpdateState()
    {
        Debug.Log("Player Start Update!");
    }

    public override void ExitState()
    {
        Debug.Log("Player Start End!");
        
        //battleController.battleState.EnterState(_BattleController);
    }

}