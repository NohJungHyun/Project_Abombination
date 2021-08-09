using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking/CrowdControllBomb", order = 1)]
public class CrowdControllBomb : Bomb
{
    public int adjustNum;

    void OnEnable()
    {
        EventDiffuse += FreezeTarget;
    }

    void OnDisable()
    {
        EventDiffuse -= FreezeTarget;
    }

    void FreezeTarget(Temp_Character _Character)
    {
        Debug.Log("얼어붙어라!");

        adjustNum = _Character.GetCharacterInfo().characterMovement;

        _Character.GetCharacterInfo().characterMovement = 0;

        EventDiffuse -= FreezeTarget;

        // _Character.TurnEndDelegate += (() => ReturnState(_Character));
    }

    void ReturnState(Temp_Character _Character)
    {
        Debug.Log("얼음이 사라지노라..");
        _Character.GetCharacterInfo().characterMovement = adjustNum;

        // _Character.TurnEndDelegate -= (() => ReturnState(_Character));
    }
}
