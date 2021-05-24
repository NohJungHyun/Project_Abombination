using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CanAttached { AnyWhere, Bomb, Explosion }
public abstract class Abombination : ScriptableObject
{
    public UnityEvent unityEvent;
    public List<EventBox> canAttechedEventBox = new List<EventBox>(5);
    public List<CanAttached> canAffect = new List<CanAttached>(3);

    public abstract void ActivateEffect();
    public abstract void ActivateEffect(Temp_Character _target);


    public virtual void SpreadToEventBox()
    {
        for (int i = 0; i < canAttechedEventBox.Count; i++)
        {
            // canAttechedEventBox[i].AddEventCollection(ActivateEffect);
        }
    }

    public virtual void RemoveThisAbombination()
    {
        for (int i = 0; i < canAttechedEventBox.Count; i++)
        {
            // canAttechedEventBox[i].RemoveEventCollection(ActivateEffect);
        }
    }
}
