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
    Player player;

    bool canControlCamera = false;
    bool canControllCharacter = false;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;

        player = (Player)battleController.nowTurnContoller;
        cameraController = _battleController.cameraController;

        battleUIManager = battleController.battleUIManager;
        playThisCharacterButton = battleUIManager.turnEndButton;
    }

    public override void EnterState()
    {
        canControlCamera = true;
        battleController.SetCharacterAction(null);

        playThisCharacterButton.gameObject.SetActive(true);
        player.selectCharacterUI.gameObject.SetActive(true);
    }

    public override void UpdateState()
    {
        Debug.Log("SelectActCharacter!");

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
        {
            Debug.Log("캐릭터 선택 됨: " + SearchWithRayCast.GetHitCharacter().name);

            battleController.SetNowCharacter(SearchWithRayCast.GetHitCharacter());
            character = SearchWithRayCast.GetHitCharacter();

            // if (character.GetHaveBombs().Count > 0)
            //     CharacterInfoUI.instance.FillWithBomb(character.GetCanSetBombs());

            canControlCamera = false;

            OnSelectButton(true);
        }

        cameraController.ZoomWithWheel();

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
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
    }

    public override void ExitState()
    {

    }

    void DecidePlayCharacter()
    {
        if (battleController.nowPlayCharacter)
        {
            canControlCamera = false;
            playThisCharacterButton.gameObject.SetActive(false);
            battleUIManager.quickBarUI.SetNowCharacter(character);

            if (player.AdjustPoint(false, character.GetCharacterInfo().needCommandPoint))
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
