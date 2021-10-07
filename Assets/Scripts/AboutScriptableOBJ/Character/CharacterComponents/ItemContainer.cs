using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : CharacterComponents
{
    public List<ItemData> haveItems = new List<ItemData>();

    public ItemContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        haveItems.Clear();

        for(int i = 0; i < info.haveItems.Count; i++)
            haveItems.Add(ScriptableObject.Instantiate(info.haveItems[i]));
    }

    public List<ItemData> GetHaveItems()
    {
        return haveItems;
    }

    public List<ActiveItem> GetPreparedItems()
    {
        return info.preparedItems;
    }
}
