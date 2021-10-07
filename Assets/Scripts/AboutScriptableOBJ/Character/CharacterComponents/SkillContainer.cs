using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : CharacterComponents
{

    public List<SkillData> haveSkills = new List<SkillData>();
    public List<SkillData> preparedSkills = new List<SkillData>();

    public SkillContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        haveSkills = info.haveSkills;
    }

    public List<SkillData> GetHaveSkills()
    {
        return haveSkills;
    }

    public List<ActiveSkill> GetPreparedSkills()
    {
        return info.preparedSkills;
    }
}
