using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType{NONE, ACTIVE, PASSIVE, TOGGLE}
public enum SkillCooltimeType{NONE, REALTIME, TURN, PHASE, ROUND}

public abstract class SkillData : NeedOwnerThings
{
    public SkillType skillType = SkillType.NONE;

    public SkillCooltimeType skillCooltimeType = SkillCooltimeType.NONE;
    public float cooltime;

    public abstract bool CheckCondition();

}
