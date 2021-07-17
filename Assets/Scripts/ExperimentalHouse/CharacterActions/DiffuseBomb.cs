using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/DiffuseBomb")]
public class DiffuseBomb : ModifyAbombination
{
    public DiffuseBomb(BattleController _battleController) : base(_battleController)
    {
        
    }

    public override IEnumerator EnterState()
    {
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        yield return null;
    }

    public override IEnumerator PhysicUpdateState()
    {
        yield return null;
    }

    public override IEnumerator ExitState()
    {
        yield return null;
        // throw new System.NotImplementedException();
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
