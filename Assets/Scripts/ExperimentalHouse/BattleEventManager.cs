using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public delegate void eventDelegate(Temp_Character owner, List<Temp_Character> targets);

    public static List<BattleEventBox> battleStartEventBox;
    public static List<BattleEventBox> battleEndEventBox;
    public static List<BattleEventBox> phaseStartEventBox;
    public static List<BattleEventBox> phaseEndEventBox;
    public static List<BattleEventBox> characterTurnStartEventBox;
    public static List<BattleEventBox> characterTurnDoEventBox;
    public static List<BattleEventBox> characterTurnEndEventBox;

    private void Awake()
    {
        battleStartEventBox = null;
        battleStartEventBox = new List<BattleEventBox>();
    }

    public void CreateEventBox(Temp_Character _owner, List<Temp_Character> _targets, int _invokeSpeed, int _remainTime,List<BattleEventBox>[] eventStores, eventDelegate _event)
    {
        BattleEventBox bb = new BattleEventBox(_owner, _targets, _invokeSpeed, _remainTime);
        bb.SetEvent(_event);
        
        for(int i = 0; i < eventStores.Length; i++)
            eventStores[i].Insert(_invokeSpeed, bb);
    }

    public void InvokeEventBoxes(List<BattleEventBox> eventStore)
    {
        for(int e = 0; e < eventStore.Count; e++)
        {
            eventStore[e].InvokeEvent();
            eventStore[e].remainTime--;

            if(eventStore[e].remainTime <= 0)
            {
                eventStore[e].ResetEvent();
                eventStore.Remove(eventStore[e]);
            }
        }
    }
}


public class BattleEventBox : IEventCarrior
{
    public event BattleEventManager.eventDelegate eventBox;

    int invokeSpeed;
    public int remainTime;

    Temp_Character owner;
    List<Temp_Character> targets = new List<Temp_Character>();

    public BattleEventBox(Temp_Character _owner, List<Temp_Character> _targets, int _invokeSpeed, int _remainTime)
    {
        owner = _owner;
        targets = _targets;
        invokeSpeed = _invokeSpeed;
        remainTime = _remainTime;

        eventBox = null;
    }

    public void SetEvent(BattleEventManager.eventDelegate eventDelegate) => eventBox += eventDelegate;

    // public void RemoveEvent(BattleEventManager.eventDelegate eventDelegate) => eventBox -= eventDelegate;

    public void InvokeEvent() => eventBox?.Invoke(owner, targets);

    public void ResetEvent() => eventBox = null;
}



