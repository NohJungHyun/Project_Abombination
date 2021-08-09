using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // IEnumerator EnterState();
    // IEnumerator UpdateState();
    // // void UpdateState
    // IEnumerator ExitState();

    void EnterState();
    void UpdateState();
    // void FixedUpdateState();
    void ExitState();
}
