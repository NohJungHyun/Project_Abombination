using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActCharacter : BattleState
{
    Temp_Character character;

    CameraController cameraController;
    BattleUIManager battleUIManager;
    SelectCharacterUI selectCharacterUI;

    NowTurnCharacterManager nowTurnCharacterManager;
    CharacterMoveAreaController cmc;

    bool isDirectControl;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        battleUIManager = battleController.battleUIManager;
        battleUIManager.selectCharacterUIObj.SetActive(true);
        battleUIManager.turnEndButton.gameObject.SetActive(true);

        selectCharacterUI = battleUIManager.selectCharacterUIObj.GetComponent<SelectCharacterUI>();
        selectCharacterUI.Resetting(BattleParticipantsManager.nowTurnParticipant);

        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        nowTurnCharacterManager.SetNowCharacter(null);

        cameraController = _battleController.cameraController;
        selectCharacterUI.canProceed = false;
        
        cmc = null;
    }

    public override void EnterState()
    {
        Debug.Log("SelectActCharacter Enter!");
        character = null;
    }

    public override void UpdateState()
    {
        Debug.Log("SelectActCharacter Update!");

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter()) //&& SearchWithRayCast.selectedCharacter.GetParticipants() is Player)
        {
            if(cmc != null)
                if(character != SearchWithRayCast.GetHitCharacter())
                    cmc.TurnOnMoveAreaMesh(false);
            
            nowTurnCharacterManager.SetNowCharacter(SearchWithRayCast.GetHitCharacter());
            character = SearchWithRayCast.GetHitCharacter();
            cameraController.SetZoomingCharacter(character.transform);

            cmc = character.CharacterMoveAreaController;
            cmc.TurnOnMoveAreaMesh(true);

            selectCharacterUI.OnTurnEndButton(true, character);
            isDirectControl = false;
        }

        if (character)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                selectCharacterUI.DecidePlay(character);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            JumptoPhaseEnd();

        if (!character && battleUIManager.turnEndButton.isActiveAndEnabled == true)
            battleUIManager.ChangeButtonToPhaseEndButton(JumptoPhaseEnd);

        if(selectCharacterUI.canProceed)
            battleController.SetState(new PlayerTurnStartState(battleController));
        
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f)
            isDirectControl = true;

    }

    public override void LateUpdateState()
    {
        cameraController.ZoomWithWheel();
        cameraController.SwitchCameraControlToDirect(isDirectControl);
    }

    public override void ExitState()
    {
        if(battleUIManager.turnEndButton.gameObject.activeInHierarchy)
            battleUIManager.turnEndButton.gameObject.SetActive(false);
        selectCharacterUI.ShowUI(false);
    }

    public void JumptoPhaseEnd()
    {
        battleController.SetState(new PhaseEnd(battleController));
    }
}
