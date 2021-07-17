using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnEndState : BattleState
{
    NowTurnCharacterManager nowTurnCharacterManager;

    public PlayerTurnEndState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        nowTurnCharacterManager = battleController.gameObject.GetComponent<NowTurnCharacterManager>();
        //stateEventBox = BombEventManager.battleStateEventBoxDictionary[this.ToString()];
    }

    public override IEnumerator EnterState()
    {
        nowTurnCharacterManager.baseCharacterPos = Vector3.zero;

        Debug.Log("Player End Enter!");

        ExitState();
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            yield return null;
        }
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Player End Exit!");
        yield return null;
    }
}