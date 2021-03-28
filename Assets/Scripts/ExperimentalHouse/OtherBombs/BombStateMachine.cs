using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BombStateMachine
{
    BombState bombState{get; set;}
    void SetState();
}
