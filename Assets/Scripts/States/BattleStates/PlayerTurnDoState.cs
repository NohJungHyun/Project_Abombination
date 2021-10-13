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

    NowTurnCharacterManager nowTurnCharacterManager;
    CharacterActionController characterActionController;
    CharacterMovements characterMovements;
    CharacterRotation characterRotation;

    LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        cameraController = battleController.cameraController;
        characterActionController = CharacterActionController.instance;

        nowCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterMovements = nowCharacter.GetComponent<CharacterMovements>();
        characterRotation =  nowCharacter.GetComponentInChildren<CharacterRotation>();
    }

    public override void EnterState()
    {
        Debug.Log("Player Do Enter!");

        cameraController.ChangeCanChaseMousePos(true);
        // rangeMesh.transform.SetParent(nowCharacter.transform);
        //rangeMesh.transform.localPosition = Vector3.zero + new Vector3(0, nowTurnCharacterManager.GetNowCharacter().transform.position.y, 0);
        // rangeMesh.SetProperties(nowCharacter.GetCharacterInfo().characterDetectRange, 90);

        characterActionController.SetState(new WaitingOrder(battleController));
        characterRotation.CanRotate = true;

    }
    public override void UpdateState()
    {
        Debug.Log("Player Do Update!");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!EventSystem.current.IsPointerOverGameObject() && nowTurnCharacterManager.GetNowCharacter().CharacterMoveAreaController.GetVisibleTargets().Count > 0)
            {
                characterRotation.CanRotate = false;
                characterActionController.SetState(new ModifyAbombination(battleController));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || !nowCharacter.isActiveAndEnabled)
        {
            characterActionController.SetState(null);
            battleController.SetState(new SelectActCharacter(battleController));
            nowTurnCharacterManager.SetNowCharacter(null);
        }
    }

    public override void LateUpdateState()
    {
        characterRotation.RotateToDir(SearchWithRayCast.GetHitPoint());
        cameraController.SwitchCameraControlToDirect(false);
    }

    public override void ExitState()
    {
        Debug.Log("Player Do Exit!");
    }
}