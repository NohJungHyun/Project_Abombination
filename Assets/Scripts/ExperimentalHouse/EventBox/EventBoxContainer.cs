using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBoxContainer : MonoBehaviour
{
    public List<string> slotName = new List<string>();

    [SerializeField]
    public List<EventSlot> eventBoxDictionary = new List<EventSlot>();

    void Start()
    {
        for (int idx = 0; idx < slotName.Count; idx++)
        {
            eventBoxDictionary.Add(new EventSlot(idx, slotName[idx]));
        }
    }
}

[System.Serializable]
public class EventSlot
{
    public string slotName;
    public int slotIdx;

    public delegate void Dele();
    event Dele StartDele;
    event Dele UpdateDele;
    event Dele EndDele;

    public EventSlot(int idx, string sName)
    {
        StartDele = null;
        UpdateDele = null;
        EndDele = null;

        slotIdx = idx;
        slotName = sName;
    }

    public void AddEventToDele(int idx, Dele outerMethod)
    {
        switch (idx)
        {
            case 0:
                StartDele += outerMethod;
                break;
            case 1:
                UpdateDele += outerMethod;
                break;
            case 2:
                EndDele += outerMethod;
                break;
        }
    }

    public void RemoveEventToDele(int idx, Dele outerMethod)
    {
        switch (idx)
        {
            case 0:
                StartDele -= outerMethod;
                break;
            case 1:
                UpdateDele -= outerMethod;
                break;
            case 2:
                EndDele -= outerMethod;
                break;
        }
    }

    public void InvokeStartBoxByIdx()
    {
        StartDele?.Invoke();
    }

    public void InvokeUpdateBoxByIdx()
    {
        UpdateDele?.Invoke();
    }

    public void InvokeEndBoxByIdx()
    {
        EndDele?.Invoke();
    }
}
