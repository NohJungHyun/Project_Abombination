using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWinState : BattleState
{

    public BattleWinState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        //stateEventBox = BombEventManager.battleStateEventBoxDictionary["BattleWin"];
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
