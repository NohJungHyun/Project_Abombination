using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : BattleState
{
    
    public RoundStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState()
    {
        Debug.Log("Round Start Enter!");

        battleController.SetState(new SelectActCharacter(battleController));
    }

    public override void UpdateState()
    {
        //이벤트 발생 등을 여기서 처리하고...
        Debug.Log("Round Start Update!");
        
    }

    public override void ExitState()
    {
        
    }
}
