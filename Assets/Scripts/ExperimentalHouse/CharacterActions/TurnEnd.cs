using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/TurnEnd")]
public class TurnEnd : CharacterAction
{
    public TurnEnd(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        
    }

    public override void PhysicUpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public void EndCurTurn()
    {
        BattleController.instance.SetState(new PlayerTurnEndState(BattleController.instance));
    }
}