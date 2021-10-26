using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatContainer : CharacterComponents
{
     #region 4. 캐릭터 능력치 변수로부터 Stat 적용.
    public Stat statAttack;
    public Stat statDefense;
    public Stat statMove;
    public Stat statCharisma;
    public Stat statLuck;

    public Stat statThrowRange; // 폭탄 던지기 거리
    public Stat statDetectRange;

    public Stat statInitiative;
    #endregion

    public StatContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        Init();
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        statAttack = new Stat(info.characterAttack);
        statDefense = new Stat(info.characterDefense);
        statMove = new Stat(info.characterMovement);
        statCharisma = new Stat(info.characterCharisma);
        statLuck = new Stat(info.characterLuck);
        statInitiative = new Stat(info.characterInitiative);
        statDetectRange = new Stat(info.characterDetectRange);
        statThrowRange = new Stat(info.characterThrowRange);
    }
}
