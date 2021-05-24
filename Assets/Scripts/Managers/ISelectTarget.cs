using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectTarget
{
    IEnumerator SelectTarget();
    void SelectTargetInRange();
    // Start is called before the first frame update
    void CancleSelect();
}
