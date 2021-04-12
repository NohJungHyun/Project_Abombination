using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : BattleState
{
    public RoundEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        Debug.Log("Round End!");
    }

    public override void UpdateState(BattleController _BattleController)
    {

    }

    public override void ExitState(BattleController _BattleController)
    {

    }
}