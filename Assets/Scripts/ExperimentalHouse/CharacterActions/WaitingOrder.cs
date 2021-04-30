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

        characterLayer = LayerMask.GetMask("Characters");
    }

    public override void EnterCharacterAction()
    {
        if(cameraController.zoomingCharacter != nowTurnCharacter)
            cameraController.zoomingCharacter = nowTurnCharacter;
        
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void ActCharacterAction()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            if(battleController.GetCharacterAction().Equals(this))
            {
                Debug.Log("대기 상태에서 상태 변경 성공");
                battleController.SetCharacterAction(new MoveCharacter(battleController));
            }
        }
    }

    public override void ExitCharacterAction()
    {
        Debug.Log("대기 종료");
        SearchWithRayCast.ReturnBasicLayer();
    }

    public void EndCurTurn()
    {

    }
}
