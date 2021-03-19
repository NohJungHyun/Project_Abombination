using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImapctTiming{Plant, Wear, Boom, Diffuse}
public class Impact: ScriptableObject
{
    public ImapctTiming imapctTiming;
    public virtual void AdjustEffect(Temp_Character _temp_Character)
    {

    }
}
