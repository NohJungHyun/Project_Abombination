using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/AddExplosion")]
public class AddExplosion : CharacterAction
{
    public AddExplosion(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
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
        // throw new System.NotImplementedException();
    }

    // 폭발물 설치
    public static void DoExplosionSetUp(Explosion _e, UItoShowBombInfo _ui)
    {
        if (_ui.targetedCharacter && _ui.targetedCharacter.GetHaveBombs()[_ui.indexBomb])
        {
            Explosion cloneExplosion = _e;
            _ui.targetedCharacter.GetHaveBombs()[_ui.indexBomb].AddExplosionToList(_e, 0);
            //_ui.ExhibitExplosionsCondition(_ui.targetedCharacter);
            _ui.CheckBomb(_ui.targetedCharacter);
            Debug.Log("폭발물 설치");
        }
    }
}
