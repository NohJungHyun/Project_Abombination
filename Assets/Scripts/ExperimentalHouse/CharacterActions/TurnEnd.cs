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

    public override void EnterCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void CharacterDataUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterPhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    public void EndCurTurn()
    {
        BattleController.instance.SetState(new PlayerTurnEndState(BattleController.instance));
    }
}