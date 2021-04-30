using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerTurnDoState : BattleState
{
    static Button turnEndButton;
    Temp_Character nowCharacter;
    
    CameraController cameraController;

    LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.
    ConeRangeMesh coneRange;
    
    bool canLookAround = true;

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowCharacter = battleController.nowPlayCharacter;
        cameraController = battleController.cameraController;
        coneRange = battleController.coneRangeMesh;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Player Do Enter!");

        BattleUIManager battleUIManager = battleController.battleUIManager;
        battleUIManager.ActivateActionUI(true);

        canLookAround = true;
        cameraController.ChangeCanChaseMousePos(true);

        coneRange.gameObject.SetActive(true);
        coneRange.transform.SetParent(nowCharacter.transform);
        coneRange.SetProperties(nowCharacter.info.characterDetectRange, 360);
    }

    public override void UpdateState(BattleController _BattleController)
    {
        if (!nowCharacter) return;

        Debug.Log("Player Do Update!");

        nowCharacter.LookMousePos(canLookAround);
        cameraController.ControlMouseWithCharacter();  
                          
        // 폭탄 조작 상태로 이동
        if (!EventSystem.current.IsPointerOverGameObject())
        { 
            if (Input.GetKeyDown(KeyCode.Q) && coneRange.GetVisibleTargets().Count > 0)
            {
                canLookAround = false;
                Debug.Log("뭐지 버근가");
                battleController.SetCharacterAction(new ModifyAbombination(battleController));
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            battleController.SetCharacterAction(new WaitingOrder(battleController));
            battleController.SetState(new SelectActCharacter(battleController));
        }
        coneRange.transform.position = nowCharacter.transform.position;
    }

    public override void ExitState(BattleController _BattleController)
    {
        Debug.Log("Player Do Exit!");
    }
}