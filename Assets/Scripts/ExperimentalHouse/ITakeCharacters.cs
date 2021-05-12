using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeCharacters
{
    Temp_Character owner { set; }
    Temp_Character target { set; }

    void SetCharacter(Temp_Character _Character);
}
