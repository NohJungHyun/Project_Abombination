using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, ICanSetButtons, ICostable
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public int idx;
    public Sprite portrait;
    public int needCost;
    public int maxCapacity;
    public int curCapacity;


    public void SetToButton(Button _quickButton)
    {

    }

    public ICanSetButtons GetCanSet()
    {
        return this;
    }

    public Sprite GetSprite()
    {
        return portrait;
    }

    public int PayCost(int _costNum)
    {
        if(CheckCost(_costNum))
            return _costNum - needCost;
        else
            return -1;
    }

    public bool CheckCost(int _costNum)
    {
        if(needCost < _costNum)
            return true;
        else
            return false;
    }

    public void Use()
    {

    }

    public void AddToUse()
    {

    }
}
