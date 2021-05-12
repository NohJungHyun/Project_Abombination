using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CharacterAction
{
    public Attack(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public Attack(BattleController _battleController, Vector3 _target) : base(_battleController)
    {

    }

    public override void EnterCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void CharacterDataUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterPhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        throw new System.NotImplementedException();
    }
}
