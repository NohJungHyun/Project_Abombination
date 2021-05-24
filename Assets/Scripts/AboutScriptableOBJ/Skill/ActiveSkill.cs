using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : SkillData, IUsable
{
    public delegate IEnumerator ActivateDelegate();
    public ActivateDelegate Activation;

    // public List<ActivateDelegate> activateList = new List<ActivateDelegate>();

    void OnEnable()
    {
        Activation += Use;
    }

    public IEnumerator Use()
    {
        Debug.Log("액티브 스킬 사용");
        yield return null;
    }

    public void OnDisable()
    {
        Activation -= Use;
    }

}
