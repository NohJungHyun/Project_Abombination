using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/DiffuseBomb")]
public class DiffuseBomb : ModifyAbombination
{
    public DiffuseBomb(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void EnterCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.OnOffUIManager(false);
        // GetDiffuseBomb(_BattleUI.uitoShowBomb);
    }

    public override void CharacterDataUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            battleController.SetCharacterAction(new ModifyAbombination(battleController));
        }
        // throw new System.NotImplementedException();
    }

    public override void CharacterPhysicUpdate()
    {

    }

    public override void ExitCharacterAction()
    {
        bomb.Diffuse();
        // throw new System.NotImplementedException();
    }

    public void GetDiffuseBomb(UItoShowBombInfo _uitoShowBomb)
    {
        // bombs = _uitoShowBomb.targetedCharacter.GetHaveBombs();
        // bomb = _uitoShowBomb.targetedCharacter.GetHaveBombs()[_uitoShowBomb.indexBomb];
    }
}
