using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxWithTag
{
    public string boxName;
    public EventBox eventBox;
}


// 배틀 스테이트에 따라, 캐릭터 액션에 따라 이벤트를 저장했다가 사용할 목적으로 만든 이벤트 박스
public class EventBox : ScriptableObject
{
    public delegate void EventBoxDelegate();

    public event EventBoxDelegate boxEvent;

    public void AddBoxEvent(EventBoxDelegate _e)
    {
        boxEvent += _e;
    }

    public void RemoveBoxEvent(EventBoxDelegate _e)
    {
        boxEvent -= _e;
    }


    void OnDisable()
    {
        boxEvent = null;
    }

}
