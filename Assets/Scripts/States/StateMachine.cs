using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    //public BattleEventManager battleEventManager;
    public abstract void SetState(IState _state);
    public abstract void ResetState();

    public abstract IState GetState();

    public virtual void CallGarbageCollector()
    {
        Resources.UnloadUnusedAssets();
    }
}
