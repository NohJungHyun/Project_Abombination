using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectActCharacter : BattleState
{
    Temp_Character character;

    CameraController cameraController;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        character = _battleController.GetNowPlayCharacter();
        cameraController = _battleController.cameraController;
    }

    public override void EnterState(BattleController _BattleController)
    {

    }

    public override void UpdateState(BattleController _BattleController)
    {
        Debug.Log("SelectActCharacter!");

        cameraController.DirectMoveCamera();
        cameraController.ZoomWithWheel();

        if (SearchWithRayCast.GetHitCharacter())
        {
            battleController.SetTemp_Character(SearchWithRayCast.GetHitCharacter());
        }

        if (Input.GetKeyDown(KeyCode.Space) && battleController.nowPlayCharacter)
        {
            ExitState(_BattleController);
        }

    }

    public override void ExitState(BattleController _BattleController)
    {
        battleController.SetState(new PlayerTurnStartState(battleController));
    }

    public void SelectActCharacterWithMouse()
    {

    }
}
