using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventTiming { None, Start, Update, End }


// 얘는 내가 어떻게 쓰려고 했길래 이렇게 작성된 거지..?
[CreateAssetMenu(menuName = "ScriptableObjects/new ProtoBox")]
public class ProtoBox : ScriptableObject
{
    public List<EventTiming> eventTimings;

    public virtual void CallEvent()
    {
        //진행할 내용 정리
        Debug.Log("프로토박스 대기 중");
    }

    // public void AddCallEventToSlot(EventSlot slot)
    // {
    //     for (int i = 0; i < eventTimings.Count; i++)
    //     {
    //         switch (eventTimings[i])
    //         {
    //             case EventTiming.Start:
    //                 slot.StartDele += CallEvent;
    //                 break;

    //             case EventTiming.Update:
    //                 slot.UpdateDele += CallEvent;
    //                 break;

    //             case EventTiming.End:
    //                 slot.EndDele += CallEvent;
    //                 break;
    //         }
    //     }
    // }

    // public void RemoveCallEventToSlot(EventSlot slot)
    // {
    //     for (int i = 0; i < eventTimings.Count; i++)
    //     {
    //         switch (eventTimings[i])
    //         {
    //             case EventTiming.Start:
    //                 slot.StartDele -= CallEvent;
    //                 break;

    //             case EventTiming.Update:
    //                 slot.UpdateDele -= CallEvent;
    //                 break;

    //             case EventTiming.End:
    //                 slot.EndDele -= CallEvent;
    //                 break;
    //         }
    //     }
    // }
}
