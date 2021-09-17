using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/new OccurrenceTemplate/Healing Occurrence")]
public class HealingOccurrence : OccurrenceTemplate
{
    public float healiValue;

    public ParticleSystem healEffect;

    public override IEnumerator InvokeOccur(MonoBehaviour mono, Temp_Character temp_Character)
    {
        mono.StartCoroutine(OccurContent(temp_Character));
        Debug.Log("OccurrenceTemplate");
        yield return null;
    }

    public bool CheckConditionForInvoke()
    {
        Debug.Log("Owner 있음");
        return true;
    }

    protected override IEnumerator OccurContent(Temp_Character t)
    {
        owner = t;
        if(!CheckConditionForInvoke()) yield break;

        Debug.Log("!!!");
        if(healEffect != null)
            healEffect.Play();

        int healNum = (int) (owner.GetCharacterInfo().maxHP * healiValue);

        //yield return new WaitUntil(() => healEffect.isStopped == true);

        yield return null;

        if(owner.curHP + healNum > owner.GetCharacterInfo().maxHP)
            owner.curHP = owner.GetCharacterInfo().maxHP;
        else
            owner.TakeHeal(healNum);
        
        Debug.Log("체력을 재생한다");
        Debug.Log("현재 배틀 state: " + BattleController.instance.GetState());
        Debug.Log("현재 캐릭터 state: " + CharacterActionController.instance.GetState());
        Debug.Log("적용대상: "+ owner.name);

        yield return null;

        owner = null;
    }
}
