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
        Debug.Log("BattleStart!");    
        _BattleController.characterList.AddRange(_BattleController.enemyCharacterList);
        _BattleController.characterList.AddRange(_BattleController.playerCharactersList);

        _BattleController.SetState(new RoundStartState(_BattleController));
    }

    public override void UpdateState(BattleController _BattleController)
    {

    }

    public override void ExitState(BattleController _BattleController)
    {
        // Debug.Log("푸헤헤");
    }
}
