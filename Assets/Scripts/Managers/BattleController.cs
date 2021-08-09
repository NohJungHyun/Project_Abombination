using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// public enum BattlePhase { Nothing, BattleStart, RoundStart, CharacterTurnStart, CharacterTurn, CharacterTurnEnd, RoundEnd, BattleEnd }
public class BattleController : BattleStateMachine
{
    public static BattleController instance;
    public BattleUIManager battleUIManager;

    public CameraController cameraController;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    void Start()
    {
        SetState(new BattleStartState(this));
    }

    void Update()
    {
        state.UpdateState();
    }

    void LateUpdate()
    {
        state.LateUpdateState();
    }

    public override IState GetState()
    {
        return state;
    }
}
