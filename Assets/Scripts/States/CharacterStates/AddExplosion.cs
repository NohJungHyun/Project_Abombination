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

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        
    }

    public override void PhysicUpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    // 폭발물 설치
    public static void DoExplosionSetUp(Explosion _e, UItoShowBombInfo _ui)
    {
        if (_ui.targetedCharacter && _ui.targetedCharacter.CarriedBombContainer.GetHaveBombs()[_ui.indexBomb])
        {
            Explosion cloneExplosion = _e;
            _ui.targetedCharacter.CarriedBombContainer.GetHaveBombs()[_ui.indexBomb].AddExplosionToList(_e, 0);
            //_ui.ExhibitExplosionsCondition(_ui.targetedCharacter);
            _ui.CheckBomb(_ui.targetedCharacter);
            Debug.Log("폭발물 설치");
        }
    }
}
