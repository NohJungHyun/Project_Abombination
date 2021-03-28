using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBomb : CharacterAction
{
    Bomb bomb;

    public BoomBomb(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.GetBombPanel();
        _BattleUI.ShowBombInfoUI();
        
        if(_BattleUI.uitoShowBomb.targetedCharacter.GetHaveBombs()[_BattleUI.uitoShowBomb.indexBomb])
            bomb = _BattleUI.uitoShowBomb.targetedCharacter.GetHaveBombs()[_BattleUI.uitoShowBomb.indexBomb];
    }

    public override void ActCharacter()
    {
        bomb.Boom();
    }
}
