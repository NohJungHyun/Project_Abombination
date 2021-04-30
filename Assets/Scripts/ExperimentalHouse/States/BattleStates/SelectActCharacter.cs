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

    bool canControlCamera;

    public SelectActCharacter(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;

        player = battleController.player;
        cameraController = _battleController.cameraController;

        battleUIManager = battleController.battleUIManager;
        playThisCharacterButton = battleUIManager.turnEndButton;
    }

    public override void EnterState(BattleController _BattleController)
    {
        canControlCamera = true;
        battleController.SetCharacterAction(null);
    }

    public override void UpdateState(BattleController _BattleController)
    {
        Debug.Log("SelectActCharacter!");

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
        {
            Debug.Log("캐릭터 선택 됨: " + SearchWithRayCast.GetHitCharacter().name);

            battleController.SetNowCharacter(SearchWithRayCast.GetHitCharacter());
            character = SearchWithRayCast.GetHitCharacter();

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
    }

    public override void ExitState(BattleController _BattleController)
    {
        
    }

    public void DecidePlayCharacter()
    {
        if (battleController.nowPlayCharacter)
        {
            if (player.curCommandPoint >= character.info.needCommandPoint)
            {
                Debug.Log("한 번 해보자고!");

                canControlCamera = false;
                playThisCharacterButton.gameObject.SetActive(false);

                player.AdjustPoint(false, character.info.needCommandPoint);
                battleUIManager.selectCharacterUI.gameObject.SetActive(false);
                
                battleController.SetState(new PlayerTurnStartState(battleController));
            }

        }
    }

    public void OnSelectButton(bool _on)
    {
        playThisCharacterButton.gameObject.SetActive(_on);
        playThisCharacterButton.onClick.RemoveAllListeners();

        if(_on)
        {
            playThisCharacterButton.GetComponentInChildren<Text>().text = "Play Character";
            playThisCharacterButton.onClick.AddListener(() => DecidePlayCharacter());
        }
    }
}
