using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveSkill : SkillData
{    
    public virtual void Adjust()
    {
        if(!CheckCondition()) return;
    }

    public virtual void DisEngage()
    {
        
    }
}
