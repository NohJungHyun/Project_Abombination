using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/UseItem")]
public class UseItem : CharacterAction
{
    public UseItem(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
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
}
