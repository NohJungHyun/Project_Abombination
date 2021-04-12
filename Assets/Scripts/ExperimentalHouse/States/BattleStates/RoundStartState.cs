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
        Debug.Log("Round Start Enter!");

        RolltoInitiative();
        // _BattleController.nowPlayCharacter = _BattleController.characterList[0];
    }

    public override void UpdateState(BattleController _BattleController)
    {
        //이벤트 발생 등을 여기서 처리하고...
        Debug.Log("Round Start Update!");

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     battleController.ChangeNowPlayerCharacter();
        // }
        ExitState(battleController);
    }

    public override void ExitState(BattleController _BattleController)
    {
        // Debug.Log("Round Start End!");        
        // _BattleController.battleState = new PlayerTurnStartState(_BattleController);
        // _BattleController.battleState.EnterState(_BattleController);
        battleController.SetState(new SelectActCharacter(battleController));
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
        else
        {
            foreach (Temp_Character temp_Character in battleController.characterList)
            {

                temp_Character.info.statInitiative.CheckCal(0, Random.Range(1, 7), 0);
                Debug.Log(temp_Character.name + "의 우선권: " + temp_Character.info.statInitiative.resultStat);

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
