using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveItem : ItemData, IUsable
{
    public delegate IEnumerator ActivateDelegate();
    public ActivateDelegate Activation;

    // public List<ActivateDelegate> activateList = new List<ActivateDelegate>();

    public abstract IEnumerator Use();

    // void OnEnable()
    // {
    //     // if (activateList.Count < 0) return;

    //     // activateList.Add(Use);
    //     // activateList.Add(SelectTarget);
    //     Activation += Use;
    // }

    // public virtual IEnumerator Use()
    // {
    //     Activation?.Invoke();
    //     yield return null;
    // }

    // public void OnDisable()
    // {
    //     Activation -= Use;
    // }
    public IEnumerator PlayUseAnimation()
    {
        return null;
    }
}
