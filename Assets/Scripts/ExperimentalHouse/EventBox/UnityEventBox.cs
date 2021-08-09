using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventBox : MonoBehaviour
{
    [SerializeField]
    public UnityEventBoxCarrior unityEvent;

    public void Start()
    {
        unityEvent.AddListener(SetEventBox);
    }

    public void SetEventBox(int idx, int timing, EventBox _box)
    {

    }
}

[System.Serializable]
public class UnityEventBoxCarrior : UnityEvent<int, int, EventBox>
{

}
