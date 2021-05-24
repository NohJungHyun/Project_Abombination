using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BattleEventManager))]
public abstract class BattleStateMachine : MonoBehaviour
{
    public BattleState battleState;
    public BattleEventManager battleEventManager;
    public abstract void SetState(BattleState _battleState);

    void Start()
    {
        battleEventManager = GetComponent<BattleEventManager>();
    }
}
