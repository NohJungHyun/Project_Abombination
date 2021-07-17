using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndState : BattleState
{
    public BattleEndState(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
    }

    public override IEnumerator EnterState()
    {
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            yield return null;
        }
    }

    public override IEnumerator ExitState()
    {
        yield return null;
    }
}
