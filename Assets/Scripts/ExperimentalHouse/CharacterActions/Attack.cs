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
