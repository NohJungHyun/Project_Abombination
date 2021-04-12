using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnDoState : BattleState
{
    CameraController cameraController;
    Temp_Character nowCharacter;
    static Button turnEndButton;
    AreaIndicatorStorage areaIndicatorStorage;


    // public List<CharacterAction> characterActions = new List<CharacterAction>(10); // 전투에서 캐릭터가 진행가능한 액션들을 담은 리스트.

    public LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.

    public PlayerTurnDoState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowCharacter = battleController.nowPlayCharacter;
        areaIndicatorStorage = battleController.areaIndicatorStorage;

        cameraController = battleController.cameraController;
        cameraController.SetZoomingCharacter(nowCharacter);

        BattleUIManager battleUIManager = _battleController.battleUIManager;
        battleUIManager.ActivateActionUI(true);
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Player Do Enter!");
        battleController.SetCharacterAction(new WaitingOrder(_BattleController));

        OnTurnEndButton(true);
        // turnEndButton.gameObject.SetActive(true);
        // battleController.battleUIManager.SetEventToActUI(this);
    }

    public override void UpdateState(BattleController _BattleController)
    {
        if (!nowCharacter) return;

        Debug.Log("Player Do Update!");

        battleController.nowAction.ActCharacterAction();

        if(!battleController.GetTargetedCharacter()){
            cameraController.SetZoomingCharacter(nowCharacter);
        }

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
        {
            float distToTarget = Vector3.Distance(battleController.GetNowCharacterPos(), SearchWithRayCast.GetHitCharacter().transform.position);

            if (distToTarget < nowCharacter.info.characterDetectRange)
            {
                cameraController.SetZoomingCharacter(SearchWithRayCast.GetHitCharacter());
                battleController.SetTargetedCharacter(battleController.GetNowPlayCharacter());
                
                battleController.SetCharacterAction(new ModifyAbombination(battleController));
            }
        }

        if(cameraController.GetZoomingCharacter())
            cameraController.CameraZoomIn();
    }

    public override void ExitState(BattleController _BattleController)
    {
        // turnEndButton.gameObject.SetActive(false);
        turnEndButton.gameObject.SetActive(false);
        turnEndButton.onClick.RemoveAllListeners();
        battleController.SetState(new PlayerTurnEndState(_BattleController));
        Debug.Log("Player Do Exit!");
    }

    void OnTurnEndButton(bool _on)
    {
        turnEndButton = battleController.battleUIManager.turnEndButton;
        turnEndButton.gameObject.SetActive(_on);

        if (_on)
            turnEndButton.onClick.AddListener(() => this.ExitState(battleController));
        else
            turnEndButton.onClick.RemoveAllListeners();
    }

    // public void CheckWhereBombs()
    // {
    //     List<Temp_Character> detectedCharacters = new List<Temp_Character>();
    //     foreach (Collider col in Physics.OverlapSphere(battleController.nowPlayCharacter.transform.position, battleController.nowPlayCharacter.info.characterDetectRange, detectMask))
    //     {
    //         if (col.gameObject.GetComponent<Temp_Character>())
    //         {
    //             detectedCharacters.Add(col.gameObject.GetComponent<Temp_Character>());
    //         }
    //     }
    //     battleController.battleUIManager.GetCharacterPanel(detectedCharacters, battleController);
    // }
}