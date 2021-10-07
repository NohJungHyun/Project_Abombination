using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedBombContainer : CharacterComponents
{
    public List<BombData> haveBombs = new List<BombData>();

    public CarriedBombContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        haveBombs.Clear();
        
        for(int b = 0; b < info.haveBombs.Count; b++)
        {
            haveBombs.Add(ScriptableObject.Instantiate<BombData>(info.haveBombs[b]));
            haveBombs[b].SetOwner(owner);
            haveBombs[b].attachedTarget = owner;
        }        
    }
    
    public List<BombData> GetHaveBombs()
    {
        return info.haveBombs;
    }

    public void AddBombToHaveBombs(BombData _b, int _p)
    {
        info.haveBombs.Insert(_p, _b);
    }

    public void RemoveBombToHaveBombs(BombData _b)
    {
        if (info.haveBombs.Equals(_b))
            info.haveBombs.Remove(_b);
    }
}
