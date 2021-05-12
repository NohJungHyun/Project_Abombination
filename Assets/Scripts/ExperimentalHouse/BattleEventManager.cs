using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventDictionaryInBattle : SerializableDictionary<string, EventBox> { }
public class BattleEventManager : MonoBehaviour
{
    public static BattleEventManager instance;
    // public static List<EventBox> EventBoxes;

    public EventDictionaryInBattle battleStateEventBoxDictionary = new EventDictionaryInBattle();
    public EventDictionaryInBattle characterActionBoxDictionary = new EventDictionaryInBattle();

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    public void ChangeEventBoxes(EventBox _from, EventBox _to)
    {
        _to = _from;
    }

    public void ResetEventBoxes(EventBox _eb)
    {
        _eb.ResetEventCollection();
    }
}
