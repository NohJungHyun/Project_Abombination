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

    LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.
    ConeRangeMesh rangeMesh;

    bool canLookAround = true;

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        characterActionController = CharacterActionController.instance;

        nowCharacter = NowTurnCharacterManager.nowPlayCharacter;
        cameraController = battleController.cameraController;
        rangeMesh = nowTurnCharacterManager.coneRangeMesh;

        BattleUIManager battleUIManager = battleController.battleUIManager;
    }

    public override void EnterState()
    {
        Debug.Log("Player Do Enter!");

        canLookAround = true;
        cameraController.ChangeCanChaseMousePos(true);

        rangeMesh.gameObject.SetActive(true);
        rangeMesh.transform.SetParent(nowCharacter.transform);
        rangeMesh.SetProperties(nowCharacter.GetCharacterInfo().characterDetectRange, 360);

        characterActionController.SetState(new WaitingOrder(battleController));

    }
    public override void UpdateState()
    {
        Debug.Log("Player Do Update!");

        cameraController.ControlMouseWithCharacter();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!EventSystem.current.IsPointerOverGameObject() && rangeMesh.GetVisibleTargets().Count > 0)
            {
                canLookAround = false;
                Debug.Log("뭐지 버근가");
                characterActionController.SetState(new ModifyAbombination(battleController));
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || nowCharacter.GetCharacterInfo().currentHP <= 0)
        {
            characterActionController.SetState(null);
            battleController.SetState(new SelectActCharacter(battleController));
            nowTurnCharacterManager.SetNowCharacter(null);
        }

        rangeMesh.transform.position = nowCharacter.transform.position;

        // if(nowCharacter.GetCharacterInfo().currentHP <= 0)
        // {
        //     battleController.SetState(new PlayerTurnEndState(battleController));
        //     characterActionController.SetState(null);
        //     nowTurnCharacterManager.SetNowCharacter(null);
        // }
    }

    public override void ExitState()
    {
        Debug.Log("Player Do Exit!");

    }
}