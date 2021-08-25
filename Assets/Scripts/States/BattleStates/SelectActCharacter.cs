using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActCharacter : BattleState
{
    Temp_Character character;

    CameraController cameraController;
    BattleUIManager battleUIManager;
    Button playThisCharacterButton;
    Participants participants;

    NowTurnCharacterManager nowTurnCharacter;

    Vector3 pos;
    bool checkCharacter = false;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;

        cameraController = _battleController.cameraController;
        nowTurnCharacter = battleController.GetComponent<NowTurnCharacterManager>();
        battleUIManager = battleController.battleUIManager;
        playThisCharacterButton = battleUIManager.turnEndButton;
        participants = Player.instance;
    }

    public override void EnterState()
    {
        Debug.Log("SelectActCharacter Enter!");
        Debug.Log(character);
        character = null;
        playThisCharacterButton.gameObject.SetActive(true);
        participants.selectCharacterUI.gameObject.SetActive(true);

        // GlobalBattlePhase.instance.SelectActCharacterEventBox.InvokeStartBox();
    }

    public override void UpdateState()
    {
        Debug.Log("SelectActCharacter Update!");

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
        {
            Debug.Log("캐릭터 선택 됨: " + SearchWithRayCast.GetHitCharacter().name);

            nowTurnCharacter.SetNowCharacter(SearchWithRayCast.GetHitCharacter());
            character = SearchWithRayCast.GetHitCharacter();

            OnSelectButton(true);
            checkCharacter = true;
        }

        cameraController.ZoomWithWheel();

        if (Input.GetKeyDown(KeyCode.Space))
            DecidePlayCharacter();
        
        else if (!battleUIManager.selectCharacterUI.isActiveAndEnabled)
            battleController.SetState(new PlayerTurnStartState(battleController));
        
        if (Input.GetKeyDown(KeyCode.Escape))
            battleController.SetState(new PhaseEnd(battleController));
        

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            checkCharacter = false;
            cameraController.DirectMoveCamera();
        }

        if(checkCharacter)
            cameraController.MoveToCharacter(character.transform);
    }

    public override void LateUpdateState()
    {

    }

    public override void ExitState()
    {

    }

    void DecidePlayCharacter()
    {
        if (nowTurnCharacter.GetNowCharacter())
        {
            playThisCharacterButton.gameObject.SetActive(false);
            battleUIManager.quickBarUI.SetNowCharacter(character);

            if (participants.AdjustPoint(false, character.GetCharacterInfo().needCommandPoint))
                battleUIManager.selectCharacterUI.SpendCommandPoints(character.GetCharacterInfo().needCommandPoint);
        }
    }

    void OnSelectButton(bool _on)
    {
        playThisCharacterButton.gameObject.SetActive(_on);
        playThisCharacterButton.onClick.RemoveAllListeners();

        if (_on)
        {
            playThisCharacterButton.GetComponentInChildren<Text>().text = "Play Character";
            playThisCharacterButton.onClick.AddListener(() => DecidePlayCharacter());
        }
    }
}
