using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/BoomBomb")]
public class BoomBomb : CharacterAction
{
    Bomb bomb;

    public BoomBomb(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void EnterCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.GetBombPanel();
        // _BattleUI.ShowBombInfoUI();

        if (_BattleUI.uitoShowBomb.targetedCharacter.GetHaveBombs()[_BattleUI.uitoShowBomb.indexBomb])
            bomb = _BattleUI.uitoShowBomb.targetedCharacter.GetHaveBombs()[_BattleUI.uitoShowBomb.indexBomb];
    }

    public override void ActCharacterAction()
    {
        bomb.Boom();
    }

    public override void ExitCharacterAction()
    {
        throw new System.NotImplementedException();
    }
}
