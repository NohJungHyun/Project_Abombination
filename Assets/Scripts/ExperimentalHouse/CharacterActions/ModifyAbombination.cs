using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/ModifyAbombination")]
public class ModifyAbombination : CharacterAction
{
    BattleUIManager battleUIManager;
    CameraController cameraController;

    GameObject infoUI;

    public ModifyAbombination(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacter = _battleController.GetNowPlayCharacter();

        battleUIManager = battleController.battleUIManager;
        ControllUI(battleUIManager);

        cameraController = battleController.cameraController;

        EnterCharacterAction();
    }

    public override void EnterCharacterAction()
    {   
        cameraController.SetZoomCondition(true);
        Debug.Log("ModifyAbombination");
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // battleUIManager.
    }

    public override void ActCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        // throw new System.NotImplementedException();
    }
}
