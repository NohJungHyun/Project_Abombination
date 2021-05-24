using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Explosion", menuName = "ScriptableObjects/ExplosionMaking", order = 3)]
public class AttackExplosion : Explosion
{
    //한 번 폭발할 때 발생하는 효과 회수
    public int effectNum;
    public int attackDamage;

    public LayerMask layer;

    public override void OnEnable()
    {
        // base.OnEnable();
        Debug.Log("왜 안되냐;;");
        explosionBoomCarrier += DamageWithBoom;
    }

    public void DamageWithBoom(Temp_Character _target)
    {
        Debug.Log("왜 안터지냐;;");
        Collider[] cols = Physics.OverlapSphere(_target.transform.position, base.exploRadius, layer);
        for (int o = 0; o < cols.Length; o++)
        {
            cols[o].GetComponent<Temp_Character>().TakeDamage(attackDamage);
            Debug.Log("!!!: " + cols[o].GetComponent<Temp_Character>().GetCharacterInfo().currentHP);
        }
        // base.ExplosionActivate();
    }

    // Start is called before the first frame update
    // public override void ExplosionUpdate(Temp_Character _owner, Temp_Character _target)
    // {
    //     Debug.Log("나는 Explsoion: " + this.name + " 이라고 한다네, 소년");
    // }

    // public override void ExplosionDiffuse(Temp_Character _owner, Temp_Character _target)
    // {
    //     //obj.SetActive(false);
    //     Debug.Log("폭발 실패");
    // }

    // public override void ExplosionBoomWithBomb(Temp_Character _owner, Temp_Character _target)
    // {
    //     base.ExplosionBoomWithBomb(_owner, _target);
    //     Collider[] cols = Physics.OverlapSphere(_target.transform.position, base.exploRadius, layer);
    //     for (int o = 0; o < cols.Length; o++)
    //     {
    //         cols[o].GetComponent<Temp_Character>().TakeDamage(attackDamage);
    //         Debug.Log(cols[o].GetComponent<Temp_Character>().info.currentHP);
    //     }
    //     // base.ExplosionActivate();
    // }
}
