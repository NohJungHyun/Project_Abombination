using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnd : MonoBehaviour
{
    public void EndCurTurn()
    {
        BattleController.instance.SetState(new PlayerTurnEndState(BattleController.instance));
    }
}