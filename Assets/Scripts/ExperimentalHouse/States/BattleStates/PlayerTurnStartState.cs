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

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Player Start Enter!");
        // MoveReady();

        battleController.baseCharacterPos = battleController.GetNowCharacterPos();
        cameraController.SetZoomingCharacter(battleController.GetNowPlayCharacter());
        battleController.SetCharacterAction(new WaitingOrder(battleController));
        //battleController.cameraController.SetZoomCondition(true);
        battleController.SetState(new PlayerTurnDoState(_BattleController));
    }

    public override void UpdateState(BattleController _BattleController)
    {
        Debug.Log("Player Start Update!");
    }

    public override void ExitState(BattleController _BattleController)
    {
        Debug.Log("Player Start End!");
        
        //battleController.battleState.EnterState(_BattleController);
    }

    // public void MoveReady()
    // {
    //     Debug.Log("Move Ready");
    //     float indicatorScale = battleController.GetNowPlayCharacter().info.characterMovement * 1.5f;

    //     // BattleController.cameraController.doZoom = false;

    //     battleController.areaIndicatorStorage.GetCircleIndicator().SetActive(true);
    //     battleController.areaIndicatorStorage.MoveIndicator(battleController.areaIndicatorStorage.circleIndicator, battleController.baseCharacterPos);

    //     if (battleController.areaIndicatorStorage && battleController.areaIndicatorStorage.GetCircleIndicator().GetComponent<SpriteRenderer>().transform.localScale == Vector3.one)
    //     {
    //         battleController.areaIndicatorStorage.ModifyIndicatorSize(battleController.areaIndicatorStorage.circleIndicator, indicatorScale);
    //     }
    // }
}