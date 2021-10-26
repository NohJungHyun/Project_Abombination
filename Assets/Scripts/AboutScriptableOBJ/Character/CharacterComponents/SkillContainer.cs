using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : CharacterComponents
{

    public List<SkillData> haveSkills = new List<SkillData>();
    public List<SkillData> preparedSkills = new List<SkillData>();

    public SkillContainer(CharacterInfo info, Temp_Character _owner) : base(info, _owner)
    {
        this.info = info;
        owner = _owner;

        haveSkills = info.haveSkills;
        Debug.Log("Skill Container");
        Init();
    }

    public override void Init()
    {
        foreach (SkillData skillData in haveSkills)
        {
            skillData.SetOwner(owner);
            Debug.Log("owner 넣기");
        }

        foreach (PassiveSkill sd in haveSkills)
        {
            sd.Adjust();
            Debug.Log("패시브");
        }
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
