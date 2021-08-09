using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/DiffuseBomb")]
public class DiffuseBomb : ModifyAbombination
{
    public DiffuseBomb(BattleController _battleController) : base(_battleController)
    {
        
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

    public void GetDiffuseBomb(UItoShowBombInfo _uitoShowBomb)
    {
        // bombs = _uitoShowBomb.targetedCharacter.GetHaveBombs();
        // bomb = _uitoShowBomb.targetedCharacter.GetHaveBombs()[_uitoShowBomb.indexBomb];
    }
}
