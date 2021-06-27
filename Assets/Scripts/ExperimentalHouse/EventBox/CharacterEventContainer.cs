using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterActionEvent
{
    public string eventName;

    public delegate void CharacterActionDelegate();
    public event CharacterActionDelegate ca;

    // 이벤트 큐를 만들 것인가?
    // public List<CharacterActionDelegate> cas = new List<CharacterActionDelegate>();
}


public class CharacterEventContainer : MonoBehaviour
{
    public delegate void CharacterEventDelegate();
    public event CharacterEventDelegate characterEvent;

    public List<CharacterActionEvent> characterEventDelegates = new List<CharacterActionEvent>();
    public List<BoxWithTag> eventBoxes = new List<BoxWithTag>();

}
