using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventable
{
    void AddEventToEventBox(int _characterActionIdx, int _timingIdx, EventBox.EventBoxDelegate _e);
    void RemoveEventFromEventBox(int _characterActionIdx, int _timingIdx, EventBox.EventBoxDelegate _e);

    void InvokeStartBoxInList(int _idx);
    void InvokeUpdateBoxInList(int _idx);
    void InvokeEndBoxInList(int _idx);
}
