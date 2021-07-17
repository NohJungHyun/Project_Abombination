using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaitingOrder : CharacterAction
{
    CameraController cameraController;
    LayerMask characterLayer;

    CharacterActionController characterActionController;

    public WaitingOrder(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        cameraController = _battleController.cameraController;
        characterActionController = _battleController.GetComponent<CharacterActionController>();

        characterLayer = LayerMask.GetMask("Characters");
    }

    public override IEnumerator EnterState()
    {
        if (cameraController.zoomingCharacter != nowTurnCharacter)
            cameraController.SetZoomingCharacter(nowTurnCharacter.transform);

        yield return null; 
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            Debug.Log("캐릭터 액션 업데이트...");

            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                if (characterActionController.GetState().Equals(this))
                {
                    Debug.Log("대기 상태에서 상태 변경 성공");
                    characterActionController.SetState(new MoveCharacter(battleController));
                }
            }
            yield return null;
        }

    }
    public override IEnumerator PhysicUpdateState()
    {
        yield return null;
    }

    public override IEnumerator ExitState()
    {
        yield return null;
        // throw new System.NotImplementedException();
    }

    public void EndCurTurn()
    {

    }
}
