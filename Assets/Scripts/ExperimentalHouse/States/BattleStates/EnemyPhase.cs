using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : BattleState
{
    public List<Temp_Character> enemies = new List<Temp_Character>();

    public EnemyPhase(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        enemies  = battleController.enemyCharacterList;
        
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {

    }
}
