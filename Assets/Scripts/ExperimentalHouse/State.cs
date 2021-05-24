using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract IEnumerator EnterState();
    public abstract IEnumerator UpdateState();
    public abstract IEnumerator ExitState();
    BattleController battleController;

    public State(BattleController _bc)
    {
        battleController = _bc;
    }
}
