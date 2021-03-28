using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStartState : BattleState
{
    public Temp_Character character;

    public PlayerTurnStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        character = _battleController.nowPlayCharacter;
    }

    public override void EnterState(BattleController _BattleController)
    {
        // if (_BattleController.nowPlayCharacter && _BattleController.doZoom)
        battleController.battleUIManager.ActivateActionUI(true);
        battleController.cameraController.SetZoomCondition(true);
        BombManager.Countdown(character);
        // battleController.cameraController.setCharacter(character);
        // UpdateState(_BattleController);
    }

    public override void UpdateState(BattleController _BattleController)
    {
        battleController.cameraController.CameraZoomIn(character);
        // ExitState(_BattleController);
    }

    public override void ExitState(BattleController _BattleController)
    {
        battleController.SetState(new PlayerTurnDoState(_BattleController));
    }
}