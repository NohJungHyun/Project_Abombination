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

    public override IEnumerator EnterState()
    {
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        yield return null;
    }

    public override IEnumerator PhysicUpdateState()
    {
        yield return null;
    }

    public override IEnumerator ExitState()
    {
        yield return null;
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public void EndCurTurn()
    {
        BattleController.instance.SetState(new PlayerTurnEndState(BattleController.instance));
    }
}