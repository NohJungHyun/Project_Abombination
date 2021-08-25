using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : BattleState
{
    public List<Temp_Character> enemies = new List<Temp_Character>();

    public EnemyPhase(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;        
    }

    public override void EnterState()
    {
        Debug.Log("적의 차례");
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        
    }
}
