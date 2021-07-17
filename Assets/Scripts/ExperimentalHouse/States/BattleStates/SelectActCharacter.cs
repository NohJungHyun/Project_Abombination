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
    CharacterActionController characterActionController;

    BattleParticipantsManager battleParticipantsManager;

    bool canControlCamera = false;
    // bool canControllCharacter = false;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;

        cameraController = _battleController.cameraController;
        nowTurnCharacter = battleController.GetComponent<NowTurnCharacterManager>();
        characterActionController = battleController.GetComponent<CharacterActionController>();

        battleUIManager = battleController.battleUIManager;
        playThisCharacterButton = battleUIManager.turnEndButton;
        battleParticipantsManager = battleController.GetComponent<BattleParticipantsManager>();
        participants = Player.instance;
    }

    public override IEnumerator EnterState()
    {
        Debug.Log("SelectActCharacter Enter!");
        canControlCamera = true;
        // characterActionController.ResetState();

        playThisCharacterButton.gameObject.SetActive(true);
        participants.selectCharacterUI.gameObject.SetActive(true);

        yield return null;

    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            Debug.Log("SelectActCharacter Update!");

            if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
            {
                Debug.Log("캐릭터 선택 됨: " + SearchWithRayCast.GetHitCharacter().name);

                nowTurnCharacter.SetNowCharacter(SearchWithRayCast.GetHitCharacter());
                character = SearchWithRayCast.GetHitCharacter();

                canControlCamera = false;

                OnSelectButton(true);
            }

            cameraController.ZoomWithWheel();

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Debug.Log("@@!");
                canControlCamera = true;
                cameraController.DirectMoveCamera();
            }
            else if (canControlCamera == false)
            {
                cameraController.MoveToCharacter(character.transform);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DecidePlayCharacter();
            }
            else if (!battleUIManager.selectCharacterUI.isActiveAndEnabled)
            {
                battleController.SetState(new PlayerTurnStartState(battleController));
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                battleController.SetState(new EnemyPhase(battleController));
            }

            yield return null;
        }

    }

    public override IEnumerator ExitState()
    {
        yield return null;
    }

    void DecidePlayCharacter()
    {
        if (nowTurnCharacter.GetNowCharacter())
        {
            canControlCamera = false;
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
