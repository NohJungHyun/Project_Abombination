using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : BattleState
{

    public RoundStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override IEnumerator EnterState()
    {
        Debug.Log("Round Start Enter!");
        yield return null;

        battleController.SetState(new SelectActCharacter(battleController));
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            Debug.Log("Round Start Update!");
            yield return null;
        }
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Round Start Exit!");
        yield return null;
    }
}
