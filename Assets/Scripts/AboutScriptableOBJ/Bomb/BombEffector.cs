using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 심어질 때, 부착된 상태일 때, 해제될 때, 폭발할 때

public class BombEffector : Abombination
{
    public override void ActivateEffect()
    {

    }

    public override void ActivateEffect(Temp_Character _target)
    {
        throw new System.NotImplementedException();
    }
}
