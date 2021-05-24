using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking/AttackableBomb", order = 2)]
public class AttackableBomb : Bomb
{
    public int damage;
    public int targetBum;

    void OnEnable()
    {
        EventBoom += CauseDamageToTarget;
    }

    // public void SetEventToCharacterActions()
    // {
    //     EventBoom += CauseDamageToTarget;
    // }

    public void ShowString()
    {
        Debug.Log("attackableBomb이라고 해요!");
    }

    public void CauseDamageToTarget(Temp_Character _Character)
    {
        Collider[] cols = Physics.OverlapSphere(_Character.transform.position, bombRadius, layerMask);

        foreach (Collider col in cols)
        {
            col.GetComponent<Temp_Character>().TakeDamage(damage);
        }
    }

    public void OnDisable()
    {
        EventBoom -= CauseDamageToTarget;
    }
}
