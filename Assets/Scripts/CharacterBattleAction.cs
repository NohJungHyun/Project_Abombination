using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAction : MonoBehaviour
{
    // 캐릭터들의 행동을 별도로 관리하기 위해 만들어진 스크립트
    // 캐릭터들이 기본적으로 할 수 있는 행동(이동, 폭발물 설치, 폭탄 던지기 등)을 관리한다.
    // 캐릭터들이 지닌 고유의 활동들도 포함시킬 지는 미정
    // 여기서 처리한 결과를 return 해주는 것으로 결과값을 방출하자.

    public BattleController battleController;

    Temp_Character temp_Character;

    public Vector3 from; // 캐릭터가 이동하기 전에, 자신의 위치를 담은 변수. 
    public float moveDist;
    public float alreadymoveDist;

    public bool alreadyMove;

    public bool movePhase, setUpPhase;

    public void Update()
    {
        MoveOrder();
    }

    public void MoveOrder()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(alreadyMove && battleController.nowPlayCharacter != temp_Character){
                alreadyMove = false;
                alreadymoveDist = 0;
                moveDist = 0;
            }

            battleController.SearchwithRayCast();

            temp_Character = battleController.nowPlayCharacter;
            from = battleController.nowPlayCharacter.transform.position;

            if (moveDist != 0 && !alreadyMove)
            {
                alreadymoveDist += moveDist;
                
            }
        }
        else
        {
            if (temp_Character && temp_Character.canMove)
            {
                if (!alreadyMove)
                {
                    if (from != temp_Character.transform.position && alreadymoveDist + moveDist >= CalculateWalkDist(temp_Character.info.characterMovement))
                    {
                        alreadyMove = true;
                    }
                    else
                    {
                        alreadyMove = false;
                    }

                    if (battleController.hit.point != Vector3.zero)
                    {
                        WalkInFloor(temp_Character, battleController.hit.point);
                    }
                }
            }
        }
    }

    // 전장 내 이동
    public void WalkInFloor(Temp_Character _Character, Vector3 _des)
    {
        //시작 위치에서 현재 위치까지의 거리를 계산
        moveDist = Vector3.Distance(_Character.transform.position, from);

        _Character.transform.position = Vector3.MoveTowards(_Character.transform.position, new Vector3(_des.x, _Character.transform.position.y, _des.z), 1f * Time.deltaTime);

        // if (moveDist + alreadymoveDist <= CalculateWalkDist(_Character.info.characterMovement)) // + alreadymoveDist
        // {
        //     //moveDist -= Vector3.Distance(_Character.transform.position, _Character.transform.position);
        //     //moveDist = Vector3.Distance(_Character.transform.position, from);
        //   }
        // else
        // {
        //     alreadyMove = true;
        // }
    }

    // 캐릭터가 한 턴에 기본적으로 이동할 수 있는 거리 측정
    public float CalculateWalkDist(float _CharacterMovement)
    {
        float dist = _CharacterMovement * 1f;
        return dist;
    }

    public void CreateBomb()
    {
        if (temp_Character.canSetBombs.Count > 0)
        {
            for (int b = 0; b < temp_Character.canSetBombs.Count; b++)
            {

            }
        }
    }

    // 폭탄 던지기
    public void ThrowBomb()
    {

    }

    // 폭탄물 설치
    public void DoExplosionSetUp()
    {

    }

    // 폭발물 해제
    public void DoExplosionDefuse()
    {

    }
}
