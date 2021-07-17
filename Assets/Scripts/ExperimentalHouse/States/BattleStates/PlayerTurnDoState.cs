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
    bool isNowSkill;

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowTurnCharacterManager = battleController.gameObject.GetComponent<NowTurnCharacterManager>();
        characterActionController = battleController.gameObject.GetComponent<CharacterActionController>();

        nowCharacter = nowTurnCharacterManager.nowPlayCharacter;
        cameraController = battleController.cameraController;
        rangeMesh = nowTurnCharacterManager.coneRangeMesh;
    }

    public override IEnumerator EnterState()
    {
        Debug.Log("Player Do Enter!");

        BattleUIManager battleUIManager = battleController.battleUIManager;

        canLookAround = true;
        cameraController.ChangeCanChaseMousePos(true);

        rangeMesh.gameObject.SetActive(true);
        rangeMesh.transform.SetParent(nowCharacter.transform);
        rangeMesh.SetProperties(nowCharacter.GetCharacterInfo().characterDetectRange, 360);
        yield return null;
    }
    public override IEnumerator UpdateState()
    {
        while (true)
        {
            yield return null;
            cameraController.ControlMouseWithCharacter();
            
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if (!EventSystem.current.IsPointerOverGameObject() && rangeMesh.GetVisibleTargets().Count > 0)
                {
                    canLookAround = false;
                    Debug.Log("뭐지 버근가");
                    characterActionController.SetState(new ModifyAbombination(battleController));
                }
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                characterActionController.SetState(new WaitingOrder(battleController));
                battleController.SetState(new SelectActCharacter(battleController));
                nowTurnCharacterManager.SetNowCharacter(null);
            }

            rangeMesh.transform.position = nowCharacter.transform.position;
        }
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Player Do Exit!");
        yield return null;
    }
}