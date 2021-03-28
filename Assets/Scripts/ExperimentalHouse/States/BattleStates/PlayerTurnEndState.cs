using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnEndState : BattleState
{
    public PlayerTurnEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("플레이어 턴 종료");
    }

    public override void UpdateState(BattleController _BattleController)
    {

    }

    public override void ExitState(BattleController _BattleController)
    {

    }
}