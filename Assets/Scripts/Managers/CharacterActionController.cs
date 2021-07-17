using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionController : CharacterActionStateMachine
{
    public static CharacterActionController instance;

    void Awake()
    {
        if(instance != null)
            Destroy(instance);

        instance = this;
    }

}
