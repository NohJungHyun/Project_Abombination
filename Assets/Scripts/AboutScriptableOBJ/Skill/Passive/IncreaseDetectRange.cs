using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects/Skills/PassiveSkills/IncreaseDetectRange")]
public class IncreaseDetectRange : PassiveSkill
{
    [SerializeField]
    float adjustNum;

    StatCheck sc;

    public override bool CheckCondition()
    {
        return true;
    }

    public override void Adjust()
    {
        base.Adjust();
        sc = new StatCheck(adjustNum,999,0);

        // Debug.Log(owner);
        // Debug.Log(owner.StatContainer);
        // Debug.Log(owner.StatContainer.statDetectRange.resultStat);
        // owner.StatContainer.statDetectRange.AddStatCheck(sc);
        // Debug.Log("owner.StatContainer.statDetectRange.resultStat" + owner.StatContainer.statDetectRange.resultStat);

        // DisEngage();
    }

    public override void DisEngage()
    {
        owner.StatContainer.statDetectRange.RemoveStatCheck(sc);
        Debug.Log("결과 값: " + owner.StatContainer.statDetectRange.resultStat);
    }



}
