using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetBombtoCharacter", menuName = "ScriptableObjects/SetBombPosition/ToArea")]
public class SetBombtoGround : SetBombPositions
{
    // static bool setupGo = false; // 폭탄이 마우스와 같이 돌아다니는가(설치 준비 중인가?)
    static bool hasTempBomb = false; // 현재 임시적으로 폭탄을 마우스 끝에 담고 있는가?
    public static Temp_Character bombObject;

    // 폭탄에 대한 정보와 좌표 값을 가져와서 폭탄을 생성할 때 위치를 삼도록 하는 함수.
    // public override Vector3 SettoPos(Bomb _b, GameObject _target)
    // {
    //     return Vector3.zero;
    // }
    // 폭탄을 설치할 때, 랜덤하게 결정하는 지, 특정한 규칙으로 결정되는 지 파악하는 함수.
    public override void DecideSetWay(CreateBomb _createBomb)
    {
        //SetupBomb(SearchWithRayCast.hit.point, _createBomb);
    }

    // 특정 지역에 설치할 때 사용하는 설치 방식.
    public void SetupBomb(Vector3 _hitPos, CreateBomb _createBomb)
    {
        if (!hasTempBomb)
        {
            // bombObject = CreateBomb.targetBomb;
            bombObject = Instantiate(bombObject);
            hasTempBomb = true;
        }
        else
        {
            if (bombObject != null)
            {
                bombObject.transform.position = new Vector3(_hitPos.x, bombObject.transform.localScale.x * 0.5f, _hitPos.z);

                if (Input.GetMouseButtonDown(0))
                {
                   //  setupGo = false;
                    GameObject actualObj = bombObject.gameObject;

                    Instantiate(actualObj);

                    bombObject.gameObject.SetActive(false);
                    hasTempBomb = false;

                    // bombs.Add(actualObj.GetComponent<Temp_Character>());

                    for (int i = 0; i < actualObj.GetComponent<Temp_Character>().GetCharacterInfo().haveBombs.Count; i++)
                    {
                        Bomb b = actualObj.GetComponent<Temp_Character>().GetCharacterInfo().haveBombs[i];
                        b.SetCountDown();
                        // b.SetbombOwner(_createBomb.bombOwner);
                        Debug.Log(b.bombCurCountDown);
                    }
                    // bombs.Add(actualObj.GetComponent<Temp_Character>());
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Destroy(bombObject);
                }
            }
        }
    }

}
