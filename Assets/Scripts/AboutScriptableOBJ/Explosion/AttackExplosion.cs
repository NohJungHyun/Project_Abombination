using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackExplosion: Explosion
{
    //한 번 폭발할 때 발생하는 효과 회수
    public int effectNum;
    public int attackDamage;

    public LayerMask layer;
    // Start is called before the first frame update
    public override void ExplosionActivate(GameObject obj)
    {
        Collider[] cols = Physics.OverlapSphere(obj.transform.position, base.exploRadius, layer);
        for(int o = 0; o < cols.Length; o++){
            cols[o].GetComponent<CharacterInfo>().TakeDamage(attackDamage);
        } 
        // base.ExplosionActivate();
    }

    public override void ExplosionDiffuse(GameObject obj)
    {
        // base.ExplosionDiffuse();
    }



    
}
