using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyCountDown : ModifyAbombination, IBombCatch
{
    public ModifyCountDown(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void EnterCharacterAction()
    {
        //throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void ActCharacterAction()
    {
        //throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        //throw new System.NotImplementedException();
    }
}
