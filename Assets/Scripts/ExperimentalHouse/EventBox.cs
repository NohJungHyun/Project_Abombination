using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class EventBox : ScriptableObject
{
    public delegate void EventBoxDelegate();
    public event EventBoxDelegate characterActionEventBoxDelegate;
    public Queue<EventBoxDelegate> eventBoxQueue;

    public virtual void InvokeEventQueue()
    {
        if(eventBoxQueue.Count > 0)
        {
            EventBoxDelegate ed = eventBoxQueue.Peek();
            ed?.Invoke();

            eventBoxQueue.Dequeue();
        }
    }

    public virtual void ResetEventsInQueue()
    {
        eventBoxQueue = null;
    }
}
