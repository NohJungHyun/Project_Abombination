using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemData : NeedOwnerThings
{
    // public int needCost;
    public int maxCapacity;
    public int curCapacity;
    public bool canStack;

    public ItemData GetItemData()
    {
        return this;
    }
}
