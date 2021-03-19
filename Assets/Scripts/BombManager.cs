using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    // 전투 내 다뤄질 폭탄의 처리를 도맡는 스크립트
    // 오브젝트풀링을 이용하여 다량의 폭탄처리를 진행.

    //현재 전장 내 존재하는 폭탄의 개수를 담는 큐 제작.
    [SerializeField]
    public List<Temp_Character> bombs = new List<Temp_Character>();

    // public BattleController battle;

    // 턴, 라운드가 진행될 때마다 카운트 다운되는 걸 계산, 처리하기 위해 만든 delegate;
    // public delegate void CountdownChecker();
    // public static CountdownChecker turnChecker;

    // public Vector3 setupPos;
    public bool setupGo = false; // 폭탄이 마우스와 같이 돌아다니는가(설치 준비 중인가?)
    public bool hasTempBomb = false; // 현재 임시적으로 폭탄을 마우스 끝에 담고 있는가?

    public Temp_Character bObject;
    public Temp_Character boomer;

    public void Countdown()
    {
        for (int c = 0; c < bombs.Count; c++)
        {
            for (int b = 0; b < bombs[c].haveBombs.Count; b++)
            {
                bombs[c].haveBombs[b].bombCurCountDown--;
                Debug.Log(bombs[c].haveBombs[b].name +" "+ bombs[c].haveBombs[b].bombCurCountDown);

                if (bombs[c].haveBombs[b].bombCurCountDown <= 0)
                {
                    bombs[c].haveBombs[b].Boom();
                }
            }
            if(bombs[c].haveBombs.Count <= 0){
                bombs.Remove(bombs[c]);
            }
        }
    }

    public void CreateBombtoButtonClick(Temp_Character _tempCharacter, bool _needSetupChance)
    {
        bObject = _tempCharacter;

        if (_needSetupChance && !setupGo)
            setupGo = true;
    }

    public void ReadytoSetup(Vector3 _hitPos, Temp_Character _Character)
    {
        if (!hasTempBomb)
        {
            bObject = Instantiate(bObject);
            hasTempBomb = true;
        }
        else
        {
            if (bObject != null)
            {
                bObject.transform.position = new Vector3(_hitPos.x, bObject.transform.localScale.x * 0.5f, _hitPos.z);

                if (Input.GetMouseButtonDown(0))
                {
                    setupGo = false;
                    GameObject actualObj = bObject.gameObject;

                    Instantiate(actualObj);

                    bObject.gameObject.SetActive(false);
                    hasTempBomb = false;

                    // bombs.Add(actualObj.GetComponent<Temp_Character>());

                    for (int i = 0; i < actualObj.GetComponent<Temp_Character>().haveBombs.Count; i++)
                    {
                        Bomb b = bObject.haveBombs[i];
                        b.SetCountDown();
                        b.SetbombOwner(_Character);
                        Debug.Log(b.bombCurCountDown);
                    }
                    bombs.Add(actualObj.GetComponent<Temp_Character>());
                    
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Destroy(bObject);
                }
            }
        }
    }
    public void GetBoomer(Temp_Character _tempCharacter){
        boomer = _tempCharacter;
    }
}