using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsInGame : ScriptableObject
{
    public string thingsName;
    public int idx;

    [TextArea]
    public string desc;
    public Sprite portrait;

    public Sprite GetSprite()
    {
        return portrait;
    }

    public string GetDesc()
    {
        return desc;
    }

    public string GetName()
    {
        return thingsName;
    }

    public ThingsInGame GetThisData()
    {
        return this;
    }
}
