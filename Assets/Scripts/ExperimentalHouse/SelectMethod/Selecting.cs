using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Selecting", menuName = "Project_Abombination/Selecting", order = 0)]
public class Selecting : ScriptableObject
{
    public Transform target;

    public virtual List<Transform> Select(Transform t)
    {
        return null;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}

