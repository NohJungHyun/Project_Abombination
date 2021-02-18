using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetBombtoCharacter", menuName = "ScriptableObjects/SetBombPosition/ToCharacter")]
public class SetBombtoCharacter : SetBombPositions
{
    //  public BattleController battleController;public BattleController battleController;

    // 폭탄에 대한 정보와 좌표 값을 가져와서 폭탄을 생성할 때 위치를 삼도록 하는 함수.
    public override Vector3 SettoPos(Bomb _b, GameObject _target)
    {
        return SetCharacter();
    }

    // 폭탄을 설치할 때, 랜덤하게 결정하는 지, 특정한 규칙으로 결정되는 지 파악하는 함수.
    public override void DecideSetWay()
    {

    }

    public Vector3 SetCharacter()
    {
        Vector3 trans = Vector3.zero;

        if (battleController)
        {
            if (battleController.hit.collider.tag == "Character")
            {
                trans = battleController.hit.collider.transform.position;
            }
            else
            {

            }
        }

        return trans;
    }

}
