using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCarrior : MonoBehaviour
{
    public Bomb bomb;

    public List<IBombEventExcutor> excutors = new List<IBombEventExcutor>(4);
    public BombEventBoom bombEventBoom;

    public void Start()
    {
        bombEventBoom.bomb = bomb;
    }

    public void AddEventToBox(IBombEventExcutor _IExcutor, BombEventBox _eventBox)
    {
        for (int i = 0; i < excutors.Count; i++)
        {
            if (_IExcutor.Equals(excutors[i]))
                _IExcutor.eventBox += _eventBox;
        }
    }

    public void RemoveEventToBox(IBombEventExcutor _IExcutor, BombEventBox _eventBox)
    {
        for (int i = 0; i < excutors.Count; i++)
        {
            if (_IExcutor.Equals(excutors[i]))
                _IExcutor.eventBox -= _eventBox;
        }
    }

    public void SetEvent()
    {
        AddEventToBox(bombEventBoom, ShowString);
    }

    public void ShowString(Temp_Character _Character)
    {
        print("홀로라이브");
    }
}
