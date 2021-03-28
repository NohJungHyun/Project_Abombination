using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetBombtoCharacter", menuName = "ScriptableObjects/SetBombPosition/ToMe")]
public class SetBombtoMe : SetBombPositions
{
    // 폭탄에 대한 정보와 좌표 값을 가져와서 폭탄을 생성할 때 위치를 삼도록 하는 함수.

    // public override Vector3 SettoPos(Bomb _b, GameObject _target)
    // {
    //     return Vector3.zero;
    // }

    // 폭탄을 설치할 때, 랜덤하게 결정하는 지, 특정한 규칙으로 결정되는 지 파악하는 함수.
    public override void DecideSetWay(CreateBomb _createBomb)
    {

    }

    public void SelectMe()
    {
        
    }

}

