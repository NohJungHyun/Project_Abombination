using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnStartState : BattleState
{
    Temp_Character character;

    CameraController cameraController;

    public PlayerTurnStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        character = _battleController.GetNowPlayCharacter();
        cameraController = _battleController.cameraController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Player Start Enter!");

        character = _BattleController.nowPlayCharacter;

        battleController.cameraController.SetZoomCondition(true);

        if (character && character.GetHaveBombs().Count > 0)
        {
            Debug.Log("카운트 다운!");
            BombManager.Countdown(character);
        }
    }

    public override void UpdateState(BattleController _BattleController)
    {
        Debug.Log("Player Start Update!");
    }

    public override void ExitState(BattleController _BattleController)
    {
        Debug.Log("Player Start End!");
        battleController.SetState(new PlayerTurnDoState(_BattleController));
        //battleController.battleState.EnterState(_BattleController);
    }
}