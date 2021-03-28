using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTurnDoState : BattleState
{
    CameraController cameraController;
    Temp_Character character;

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        cameraController = battleController.cameraController;
        character = battleController.nowPlayCharacter;
    }

    public override void EnterState(BattleController _BattleController)
    {

    }

    public override void UpdateState(BattleController _BattleController)
    {

    }

    public override void ExitState(BattleController _BattleController)
    {

    }
}