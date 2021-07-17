using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(BattleController _battleController) : base(_battleController)
    {

    }

    public override IEnumerator EnterState()
    {
        Debug.Log("Battle Start Enter!");
        yield return null;
        battleController.SetState(new RoundStartState(battleController));
        
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
