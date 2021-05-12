using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillData : ScriptableObject, ICanSetButtons, ICostable
{
    public string skillName;
    [TextArea]
    public string skillDescription;
    public Sprite skillImage;
    public bool skillEarnPrerequisite; // 스킬 획득 시 조건
    public bool skillUsePrerequisite; // 스킬 사용 시 조건

    public int canUseNum; // 사용 가능 횟수
    public int needCost; //스킬 사용을 위해 소비해야하는 액션 포인트의 개수

    public int damage; //스킬로 입힐 수 있는 피해

    public void Use()
    {

    }

    public void AddToUse()
    {

    }

    public void SetToButton(Button _b)
    {
        _b.image.sprite = skillImage;
    }

    public Sprite GetSprite()
    {
        return skillImage;
    }

    public ICanSetButtons GetCanSet()
    {
        return this;
    }

    public int PayCost(int _costNum)
    {
        if (CheckCost(_costNum))
            return _costNum - needCost;
        else
            return -1;
    }

    public bool CheckCost(int _costNum)
    {
        if (needCost < _costNum)
            return true;
        else
            return false;
    }
}
