using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEventPlant : MonoBehaviour, IBombEventExcutor
{
    public event BombEventBox eventBox;

    public void Excute(Temp_Character _Character)
    {
        eventBox?.Invoke(_Character);
    }
}
