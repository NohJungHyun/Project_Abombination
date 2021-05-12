using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventBox : ScriptableObject
{
    public delegate void EventDelegate();
    public event EventDelegate eventCollection;

    public virtual void InvokeEventCollection()
    {
        eventCollection?.Invoke();
    }

    public virtual void ResetEventCollection()
    {
        eventCollection = null;
    }

    public virtual void SetEventCollection(EventDelegate _e)
    {
        eventCollection = _e;
    }

    public virtual void AddEventCollection(EventDelegate _e)
    {
        eventCollection += _e;
    }

    public virtual void RemoveEventCollection(EventDelegate _e)
    {
        eventCollection -= _e;
    }
}
