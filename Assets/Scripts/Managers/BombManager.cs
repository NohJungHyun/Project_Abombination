using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BombManager
{
    // 전투 내 다뤄질 폭탄의 처리를 도맡는 스크립트
    // 오브젝트풀링을 이용하여 다량의 폭탄처리를 진행.

    //현재 전장 내 존재하는 폭탄의 개수를 담는 큐 제작.
    [SerializeField]
    public static List<BombData> entireBombs = new List<BombData>();

    // public static void Countdown(Temp_Character _Character)
    // {
    //     foreach(Bomb bomb in _Character.GetHaveBombs()){
    //         bomb.bombCurCountDown--;

    //         if(bomb.bombCurCountDown <= 0){
    //             bomb.bombCurCountDown = 0;
    //             bomb.Boom();
    //         }
    //     }
    // }

    public static void AddBombToEntire(BombData _bomb)
    {
        entireBombs.Add(_bomb);
    }

    public static void RemoveBombFromEntire(BombData _bomb)
    {
        if(entireBombs.Contains(_bomb))
        {
            entireBombs.Remove(_bomb);
        }
    }

    // public void CreateBombtoButtonClick(Temp_Character _tempCharacter, bool _needSetupChance)
    // {
    //     bObject = _tempCharacter;

    //     if (_needSetupChance && !setupGo)
    //         setupGo = true;
    // }

    // public void ReadytoSetup(Vector3 _hitPos, Temp_Character _Character)
    // {
    //     if (!hasTempBomb)
    //     {
    //         bObject = Instantiate(bObject);
    //         hasTempBomb = true;
    //     }
    //     else
    //     {
    //         if (bObject != null)
    //         {
    //             bObject.transform.position = new Vector3(_hitPos.x, bObject.transform.localScale.x * 0.5f, _hitPos.z);

    //             if (Input.GetMouseButtonDown(0))
    //             {
    //                 setupGo = false;
    //                 GameObject actualObj = bObject.gameObject;

    //                 Instantiate(actualObj);

    //                 bObject.gameObject.SetActive(false);
    //                 hasTempBomb = false;

    //                 // bombs.Add(actualObj.GetComponent<Temp_Character>());

    //                 for (int i = 0; i < actualObj.GetComponent<Temp_Character>().haveBombs.Count; i++)
    //                 {
    //                     Bomb b = bObject.haveBombs[i];
    //                     b.SetCountDown(b.bombCurCountDown, b.bombMinCountDown, b.bombMaxCountDown);
    //                     b.SetbombOwner(_Character);
    //                     Debug.Log(b.bombCurCountDown);
    //                 }
    //                 bombs.Add(actualObj.GetComponent<Temp_Character>());

    //             }
    //             else if (Input.GetMouseButtonDown(1))
    //             {
    //                 Destroy(bObject);
    //             }
    //         }
    //     }
    // }
    // public void GetBoomer(Temp_Character _tempCharacter){
    //     boomer = _tempCharacter;
    // }
}