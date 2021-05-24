using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillData : NeedOwnerThings
{
    public bool skillEarnPrerequisite; // 스킬 획득 시 조건
    public bool skillUsePrerequisite; // 스킬 사용 시 조건

    // 대상을 선택해야 하는 지 물어보는 변수
    public bool needTarget;

    public int canUseNum; // 사용 가능 횟수
    public int needCost; //스킬 사용을 위해 소비해야하는 액션 포인트의 개수    

    public int cooltime;

    public int costActionPoint;
}
