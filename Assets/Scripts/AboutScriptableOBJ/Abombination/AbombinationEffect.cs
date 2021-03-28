using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectTiming { AnyTime, SetUp, Atteched, Diffuse, Boom }
public enum CanAttached { AnyWhere, Bomb, Explosion }
public abstract class AbombinationEffect : ScriptableObject
{
    // Bomb, Explosion 등에 부착시켜서 발휘하는 효과를 의미.

    // Bomb ownerBomb;

    // protected Temp_Character temp_Character;
    public List<EffectTiming> effectTiming = new List<EffectTiming>(5);
    public List<CanAttached> canAffect = new List<CanAttached>(3);

    public abstract void ActivateEffect(Temp_Character _Character);

    // public virtual void SetBomb(Bomb _bomb)
    // {
    //     ownerBomb = _bomb;
    // }

    // public virtual void SetCharacterInfo(Temp_Character _temp_Character)
    // {
    //     temp_Character = _temp_Character;
    // }
}
