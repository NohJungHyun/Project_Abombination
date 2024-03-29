using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking/AttackableBomb", order = 2)]
public class AttackableBomb : BombData
{
    public int damage;
    public int targetNum;

    // void OnEnable()
    // {
    //     EventBoom += CauseDamageToTarget;
    //     owner.GetComponent<CharacterEventContainer>().eventBoxDictionary[5].AddEventToDele(0, ShowString);
    // }

    // private void OnDisable() 
    // {
    //     EventBoom -= CauseDamageToTarget;
    //     owner.GetComponent<CharacterEventContainer>().eventBoxDictionary[5].RemoveEventToDele(0, ShowString);
    // }

    public override void Boom()
    {
        base.Boom();
        CauseDamageToTarget(attachedTarget);
    }

    public void ShowString()
    {
        Debug.Log("attackableBomb이라고 해요!");
    }

    public void CauseDamageToTarget(Temp_Character _Character)
    {
        Collider[] cols = Physics.OverlapSphere(_Character.transform.position, bombRadius, layerMask);

        foreach (Collider col in cols)
        {
            col.GetComponent<Temp_Character>().TakeDamage(damage + GetOwner().GetCharacterInfo().characterAttack);
        }
    }
}
