using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(BattleController _battleController) : base(_battleController)
    {
        // if(battleController)
        //     SetEventBox(BattleEventManager.instance.battleStateEventBoxDictionary["BattleStart"]);
    }

    public override void EnterState()
    {
        Debug.Log("BattleStart!");  

        // for(int i = 0; i < battleEventManager.battleStartList.Count; i++)
        // {
        //     battleEventManager.battleStartList[i]?.Invoke();
        // }
          
        battleController.characterList.AddRange(battleController.enemyCharacterList);
        battleController.characterList.AddRange(battleController.playerCharactersList);

        battleController.SetState(new RoundStartState(battleController));
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        // Debug.Log("푸헤헤");
    }
}
