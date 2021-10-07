using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSetBombsContainer : CharacterComponents
{
    public List<BombData> canSetBombs = new List<BombData>();
    public List<BombData> preparedBombs = new List<BombData>();

    public CanSetBombsContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지: " + owner);
    }

    public override void Init()
    {
        canSetBombs.Clear();
        preparedBombs.Clear();

        for (int b = 0; b < info.canSetBombs.Count; b++)
        {
            canSetBombs.Add(ScriptableObject.Instantiate<BombData>(info.canSetBombs[b]));
            canSetBombs[b].SetOwner(owner);
        }
    }

    public List<BombData> GetCanSetBombs()
    {
        return canSetBombs;
    }

    public void AddBombToCanSetBombs(BombData _b, int _p)
    {
        canSetBombs.Insert(_p, _b);
    }

    public void RemoveBombtoCanSetBombs(BombData _b)
    {
        if (canSetBombs.Equals(_b))
            canSetBombs.Remove(_b);
    }
}
