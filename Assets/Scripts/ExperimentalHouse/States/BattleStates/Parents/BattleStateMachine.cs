using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleStateMachine : MonoBehaviour
{
    public BattleState battleState;
    public abstract void SetState(BattleState _battleState);
}
