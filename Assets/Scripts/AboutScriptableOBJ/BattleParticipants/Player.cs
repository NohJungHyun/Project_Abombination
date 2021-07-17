using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Participants
{
    public static Player instance;
    
    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }
}
