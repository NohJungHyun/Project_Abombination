using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedOwnerThings : ThingsInGame
{
    protected Temp_Character owner;

    public Temp_Character GetOwner()
    {
        return owner;
    }

    public void SetOwner(Temp_Character _owner)
    {
        owner = _owner;
    }
}
