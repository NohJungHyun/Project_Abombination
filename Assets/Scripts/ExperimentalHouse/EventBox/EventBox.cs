using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 배틀 스테이트에 따라, 캐릭터 액션에 따라 이벤트를 저장했다가 사용할 목적으로 만든 이벤트 박스
[CreateAssetMenu(menuName = "ScriptableObjects/new EventBox")]
public class EventBox : ScriptableObject // , IEventable
{
    //event => UnityEvent로 변경 진행
    
    public delegate void EventBoxDelegate();

    public EventBoxDelegate startBox;
    public EventBoxDelegate updateBox;
    public EventBoxDelegate endBox;

    public void AddEventToStartBox(int _idx, EventBoxDelegate _e)
    {
        switch (_idx)
        {
            case 0:
                startBox += _e;
                break;

            case 1:
                updateBox += _e;
                break;

            case 2:
                endBox += _e;
                break;
        }
    }

    public void RemoveEventToStartBox(int _idx, EventBoxDelegate _e)
    {
        switch (_idx)
        {
            case 0:
                startBox -= _e;
                break;

            case 1:
                updateBox -= _e;
                break;

            case 2:
                endBox -= _e;
                break;
        }
    }

    public void InvokeStartBox()
    {
        startBox?.Invoke();
    }
    public void InvokeUpdateBox()
    {
        updateBox?.Invoke();
    }
    public void InvokeEndBox()
    {
        endBox?.Invoke();
    }
}
