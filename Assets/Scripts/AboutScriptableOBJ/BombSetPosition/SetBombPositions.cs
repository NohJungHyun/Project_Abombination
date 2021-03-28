﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetBombPositions : ScriptableObject
{
    public CreateBomb createBomb;
    public Temp_Character temp_Character;
    public bool isNeedSetup;
    public LayerMask layer;

    // 폭탄에 대한 정보와 좌표 값을 가져와서 폭탄을 생성할 때 위치를 삼도록 하는 함수.
    // 폭탄을 설치할 위치와 폭탄의 정보를 가져옴.
    // public abstract Vector3 SettoPos(Bomb _b, GameObject _target);

    // 폭탄을 설치할 때, 랜덤하게 결정하는 지, 특정한 규칙으로 결정되는 지 파악하는 함수.
    public abstract void DecideSetWay(CreateBomb _create);

    public virtual void SetCharacter(Temp_Character _Character)
    {
        temp_Character = _Character;
    }
}
