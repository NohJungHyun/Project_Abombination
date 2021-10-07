using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAreaController : CharacterComponents
{
    public CharacterMoveAreaController(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {

    }
}
