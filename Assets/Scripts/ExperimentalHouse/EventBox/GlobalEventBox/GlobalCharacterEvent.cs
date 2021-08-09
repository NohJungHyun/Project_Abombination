using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterEvent : GlobalEventContainer
{
    public static GlobalCharacterEvent instance;

    [Header("캐릭터 자체 행동")]
    public EventBox waitingOrderEventBox;
    public EventBox moveEventBox;
    public EventBox useSkillEventBox;
    public EventBox useItemEventBox;
    public EventBox runBattleEventBox;

    [Header("턴")]
    public EventBox turnStartEventBox;
    public EventBox turnEndEventBox;

    [Header("폭탄")]
    public EventBox createBombEventBox;
    public EventBox diffuseBombEventBox;
    public EventBox boomBombEventBox;
    public EventBox modifyCountDownEventBox;

    [Header("폭발물")]
    public EventBox addExplosionEventBox;
    public EventBox removeExplosionEventBox;

    private void Awake()
    {
        if (instance)
            Destroy(instance);

        instance = this;
    }
}
