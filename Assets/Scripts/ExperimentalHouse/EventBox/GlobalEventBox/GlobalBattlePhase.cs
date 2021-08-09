using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalBattlePhase : GlobalEventContainer
{
    public static GlobalBattlePhase instance;

    [Header("배틀")]
    public EventBox battleStartEventBox;
    public EventBox battleEndEventBox;
    public EventBox battleWinEventBox;
    public EventBox battleEventBox;

    [Header("라운드")]
    public EventBox roundStartEventBox;
    public EventBox roundEndEventBox;

    [Header("캐릭터 선택")]
    public EventBox SelectActCharacterEventBox;

    [Header("플레아어 턴 진행")]
    public EventBox playerTurnStartEventBox;
    public EventBox playerTurnDoEventBox;
    public EventBox playerTurnEndEventBox;

    private void Awake()
    {
        if (instance)
            Destroy(instance);

        instance = this;
    }
}
