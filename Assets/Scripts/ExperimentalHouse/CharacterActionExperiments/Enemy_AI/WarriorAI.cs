using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarriorAI : EnemyMind
{
    NavMeshAgent agent;

    public WarriorAI(Temp_Character _Character) : base(_Character)
    {
        controlledCharacter = _Character;
    }

    public void SetBase()
    {

    }

    // public bool SelectTarget()
    // {
    //     if (BattleController.instance.playerCharactersList.Count > 0)
    //     {
    //         float closestDist = 0;

    //         for (int t = 0; t < BattleController.instance.playerCharactersList.Count; t++)
    //         {
    //             if (Vector3.Distance(controlledCharacter.transform.position, BattleController.instance.playerCharactersList[t].transform.position) < closestDist)
    //             {
    //                 closestDist = Vector3.Distance(controlledCharacter.transform.position, BattleController.instance.playerCharactersList[t].transform.position);
    //                 agent.SetDestination(BattleController.instance.playerCharactersList[t].transform.position);
    //                 // return true;
    //             }
    //         }
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    public void Move()
    {
        // if (SelectTarget())
        // {

        // }
    }
}
