using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : ItemData, IUsable
{
    public delegate IEnumerator ActivateDelegate();
    public ActivateDelegate Activation;

    // public List<ActivateDelegate> activateList = new List<ActivateDelegate>();

    void OnEnable()
    {
        // if (activateList.Count < 0) return;

        // activateList.Add(Use);
        // activateList.Add(SelectTarget);
        Activation += Use;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Use()
    {
        yield return null;
    }

    public void OnDisable()
    {
        Activation -= Use;
    }
}
