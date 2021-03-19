using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect: ScriptableObject
{

    //public Settiming adjustTime { get; set; }
    Temp_Character temp_Character;

    public void GetCharacterInfo(Temp_Character _temp_Character)
    {
        temp_Character = _temp_Character;
    }

    public void AdjustEffect(Temp_Character _temp_Character)
    {

    }

}
