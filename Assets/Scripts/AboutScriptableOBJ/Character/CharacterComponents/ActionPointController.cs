using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPointController : CharacterComponents
{
    Stat curActionPoint;
    Stat maxActionPoint;
    Stat minActionPoint;

    public Stat MaxActionPoint{ get{ return maxActionPoint; } }
    public Stat MinActionPoint{ get{ return minActionPoint; } }
    public Stat CurActionPoint{ get{ return curActionPoint; } }

    public ActionPointController(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        maxActionPoint = new Stat(info.maxActionPoint);
        minActionPoint = new Stat(info.minActionPoint);

        curActionPoint = new Stat(info.maxActionPoint);
    }

    public void AddActionPoint(int type, int _point, int adjustSpeed = 99)
    {
        Stat s = GetActionPointType(type);
        s.SetAddStatContents(_point, adjustSpeed);
    }

    public void SubtractActionPoint(int type, int _point, int adjustSpeed = 99)
    {
        Stat s = GetActionPointType(type);
        s.SetSubtractStatContents(_point, adjustSpeed);
    }

    public void MultipleActionPoint(int type, int _point, int adjustSpeed = 99)
    {
        Stat s = GetActionPointType(type);
        s.SetMultipleStatContents(_point, adjustSpeed);
    }

    public void SetActionpoint(int type, int _point)
    {
        Stat s = GetActionPointType(type);
        s.resultStat = _point;
    }

    public Stat GetActionPointType(int type)
    {
        switch(type)
        {
            case 0: 
                return curActionPoint;
            case 1:
                return maxActionPoint;
            case 2:
                return minActionPoint;
        }
        return null;
    }

    public int GetActionPoint(int adjustTarget)
    {
        switch (adjustTarget)
        {
            case 0:
                return curActionPoint.resultStat;
            case 1:
                return maxActionPoint.resultStat;
            case 2:
                return minActionPoint.resultStat;
        }
        return -99999;
    }
}
