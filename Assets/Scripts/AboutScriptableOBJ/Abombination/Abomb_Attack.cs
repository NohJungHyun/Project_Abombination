using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects /new Abombination/new AttakEffect")]
public class Abomb_Attack : Abombination
{
    [SerializeField]
    protected string effectName;
    [SerializeField]
    protected int effectNum;
    [SerializeField]
    protected int explosionDamage;
    [SerializeField]
    protected float explosionRadius;

    public LayerMask layerMask;

    public override void ActivateEffect()
    {
        // Collider[] cols = Physics.OverlapSphere(_target.transform.position, explosionRadius, layerMask);
        // for (int c = 0; c < cols.Length; c++)
        // {
        //     if(cols[c].GetComponent<Temp_Character>())
        //         cols[c].GetComponent<Temp_Character>().TakeDamage(explosionDamage);
        // }
    }
    public override void ActivateEffect(Temp_Character _target)
    {
        Collider[] cols = Physics.OverlapSphere(_target.transform.position, explosionRadius, layerMask);
        for (int c = 0; c < cols.Length; c++)
        {
            if(cols[c].GetComponent<Temp_Character>())
                cols[c].GetComponent<Temp_Character>().TakeDamage(explosionDamage);
        }
    }
}
