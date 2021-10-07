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
        // Spread();
    }

    // void FixedUpdate()
    // {
    //     state.LateUpdateState();
    // }

    private void LateUpdate()
    {
        state.LateUpdateState();
    }

    public override IState GetState()
    {
        return state;
    }

    public void Spread()
    {
        if (BattleController.instance.GetState() is PhaseStart)
        {
            Debug.Log("PhaseStart: 이게 되네?");
        }

        if(BattleController.instance.GetState().GetType() == typeof(SelectActCharacter))
        {
            Debug.Log("SelectActCharacter: 이게 되네?");
        }
    }
}
