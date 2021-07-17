using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : BattleState
{
    public RoundEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
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