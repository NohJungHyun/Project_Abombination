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
        nowTurnCharacterManager = battleController.GetComponent<NowTurnCharacterManager>();
        characterActionController = battleController.GetComponent<CharacterActionController>();
    }

    public override IEnumerator EnterState()
    {
        Debug.Log("Player Start Enter!");
        // MoveReady();

        nowTurnCharacterManager.ResetCharacterPos();
        cameraController.SetZoomingCharacter(nowTurnCharacterManager.GetNowCharacterTransform());
        characterActionController.SetState(new WaitingOrder(battleController));

        battleController.SetState(new PlayerTurnDoState(battleController));

        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        Debug.Log("Player Start Update!");
        yield return null;
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Player Start Exit!");
        yield return null;
    }

}