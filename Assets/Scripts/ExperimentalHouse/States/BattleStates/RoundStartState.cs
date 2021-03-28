using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : BattleState
{
    public RoundStartState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
    }

    public override void EnterState(BattleController _BattleController)
    {
        RolltoInitiative();
    }

    public override void UpdateState(BattleController _BattleController)
    {
       
    }

    public override void ExitState(BattleController _BattleController)
    {

    }

    void RolltoInitiative() // 우선권 결정
    {
        if (battleController.characterList.Count == 0)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Temp_Character temp = obj.GetComponent<Temp_Character>();

                temp.info.statInitiative.CheckCal(0, Random.Range(1, 7), 0);
                Debug.Log(temp.name + "의 우선권: " + temp.info.statInitiative.resultStat);

                battleController.characterList.Add(obj.GetComponent<Temp_Character>());

                for (int t = 0; t < battleController.characterList.Count; t++)
                {
                    battleController.characterList.Sort(SortbyInitiative);
                    // Debug.Log("리스트 내 " + characterList[t].name + "의 우선도: " + characterList[t].info.statInitiative.resultStat);
                }
            }
        }
    }

    static int SortbyInitiative(Temp_Character a, Temp_Character b)
    {
        return -a.info.statInitiative.resultStat.CompareTo(b.info.statInitiative.resultStat);
    }
}
