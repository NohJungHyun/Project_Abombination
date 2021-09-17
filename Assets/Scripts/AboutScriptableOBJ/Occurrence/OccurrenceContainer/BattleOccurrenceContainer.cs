using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleOccurrenceContainer : OccurrenceContainer
{
    public static BattleOccurrenceContainer instance;

    public List<OccurrenceBox> battleStartContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> battleEndContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> battleWinContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> battleLoseContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> roundStartContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> roundEndContainer = new List<OccurrenceBox>();

    public List<OccurrenceBox> phaseStartContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> phaseEndContainer = new List<OccurrenceBox>();

    public List<OccurrenceBox> selectChracterContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> playerTurnStartContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> playerTurnDoContainer = new List<OccurrenceBox>();
    public List<OccurrenceBox> playerTurnEndContainer = new List<OccurrenceBox>();

    OccurrenceBox curBox;

    private void Awake() 
    {
        if(instance)
            Destroy(instance);
        
        instance = this;
    }

    public void InvokeContainer(int idx)
    {
        for(int i = 0; i < CallContainer(idx).Count; i++)
        {
            CallContainer(idx)[i].InvokeOccur(this);
            print(CallContainer(idx)[i].GetOwner());
            print("도달하긴 함");
        }
    }

    public List<OccurrenceBox> CallContainer(int idx)
    {
        switch (idx)
        {
            case 0:
                return battleStartContainer;
            case 1:
                return battleEndContainer;
            case 2:
                return battleWinContainer;
            case 3:
                return battleLoseContainer;
            case 4:
                return roundStartContainer;
            case 5:
                return roundEndContainer;
            case 6:
                return phaseStartContainer;
            case 7:
                return phaseEndContainer;
            case 8:
                return selectChracterContainer;
            case 9:
                return playerTurnStartContainer;
            case 10:
                return playerTurnDoContainer;
            case 11:
                return playerTurnEndContainer;
        }
        return null;
    }
}