using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{

    public BattleStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("FAQ");    
    }

    public override void UpdateState(BattleController _BattleController)
    {
        // 뭔가 처리하자...
        // 없으면 일단 패스
        ExitState(_BattleController);
    }

    public override void ExitState(BattleController _BattleController)
    {
        _BattleController.SetState(new PlayerTurnStartState(_BattleController));
        Debug.Log("???");
    }
}
