using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/UseSkill")]
public class UseSkill : CharacterAction
{
    public UseSkill(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void EnterCharacterAction()
    {

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

    }
}
