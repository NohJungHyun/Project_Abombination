using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/ModifyAbombination")]
public class ModifyAbombination : CharacterAction, IBombCatch
{
    BattleUIManager battleUIManager;
    BombModifier bombModifier;
    CameraController cameraController;

    protected Bomb bomb;

    public ModifyAbombination(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacter = _battleController.GetNowPlayCharacter();

        battleUIManager = battleController.battleUIManager;
        bombModifier = battleUIManager.bombModifier;
        cameraController = battleController.cameraController;
    }

    public override void EnterCharacterAction()
    {
        ControllUI(battleUIManager);

        cameraController.ChangeCanChaseMousePos(false);
        battleController.TransportTargetsToList();

        if(battleController.targetedCharacters.Count > 0)
            bombModifier.SetModifiedCharacter(battleController.targetedCharacters[0].GetComponent<Temp_Character>());
        else
            bombModifier.SetModifiedCharacter(nowTurnCharacter);
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        bombModifier.SetAbombinationModifier(this);
        bombModifier.gameObject.SetActive(true);
    }

    public override void CharacterDataUpdate()
    {
        cameraController.MoveToCharacter(bombModifier.modifiedCharacter.transform);
    }

    public override void CharacterPhysicUpdate()
    {
        // throw new System.NotImplementedException();
    }


    public override void ExitCharacterAction()
    {
        bombModifier.gameObject.SetActive(false);
    }

    public void ChangeModifyAction(ModifyAbombination _ma)
    {
        battleController.SetCharacterAction(_ma);
    }

    public void GetBomb(Bomb _bomb)
    {
        bomb = _bomb;
    }
}
