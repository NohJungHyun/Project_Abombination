using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : SkillData, IUsable
{

    // public List<ActivateDelegate> activateList = new List<ActivateDelegate>();

    public override bool CheckCondition()
    {
        return true;
    }
    
    public IEnumerator Use()
    {
        yield return null;
    } 

    public IEnumerator PlayUseAnimation()
    {
        return null;
    }

}
