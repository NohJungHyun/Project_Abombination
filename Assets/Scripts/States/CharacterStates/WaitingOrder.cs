using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaitingOrder : CharacterAction
{
    CameraController cameraController;
    LayerMask characterLayer;

    public WaitingOrder(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        cameraController = _battleController.cameraController;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;

        characterLayer = LayerMask.GetMask("Characters");
    }

    public override void EnterState()
    {
        Debug.Log("waiting order Enter!");

        if (cameraController.GetZoomingCharacter() != nowTurnCharacter)
            cameraController.SetZoomingCharacter(nowTurnCharacter.transform);
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void UpdateState()
    {
        Debug.Log("waiting order Update!");

        if (characterActionController.GetState().Equals(this))
        {
            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                Debug.Log("대기 상태에서 상태 변경 성공");
                characterActionController.SetState(new MoveCharacter(battleController));
            }
        }

        cameraController.MoveToCharacter(nowTurnCharacter.transform);
    }
    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {

    }

    public void EndCurTurn()
    {

    }
}
