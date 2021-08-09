using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BombEventBox(Temp_Character _Character);
public interface IBombEventExcutor 
{
    event BombEventBox eventBox;

    void Excute(Temp_Character _Character);
}
