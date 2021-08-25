using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState
{
    public abstract void EnterState(Temp_Character _character);

    public abstract void UpdateState(Temp_Character _character);

    public abstract void UpdatePhysicState();

    public abstract void ExitState(Temp_Character _character);
}
