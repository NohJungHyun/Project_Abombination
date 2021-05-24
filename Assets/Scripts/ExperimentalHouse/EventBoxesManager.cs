using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventDictionaryInBattle : SerializableDictionary<int, EventBox> { }

public class EventBoxesManager : MonoBehaviour
{
    public delegate void DelegateForEventBox();
    public event DelegateForEventBox cd;

    public virtual void AddEventToList(List<DelegateForEventBox> _list, DelegateForEventBox _cd)
    {
        _list.Add(_cd);
    }

    public virtual void RemoveEventToList(List<DelegateForEventBox> _list, DelegateForEventBox _cd)
    {
        if (_list.Contains(_cd))
        {
            _list.Remove(_cd);
        }
    }

    public virtual void InvokeEventsInList(List<DelegateForEventBox> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i]?.Invoke();
        }
    }
}
