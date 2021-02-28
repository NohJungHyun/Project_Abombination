using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    // 전투 내 다뤄질 폭탄의 처리를 도맡는 스크립트
    // 오브젝트풀링을 이용하여 다량의 폭탄처리를 진행.

    //현재 전장 내 존재하는 폭탄의 개수를 담는 큐 제작.
    [SerializeField]
    public Queue<GameObject> bombs = new Queue<GameObject>();

    // public BattleController battle;

    // 턴, 라운드가 진행될 때마다 카운트 다운되는 걸 계산, 처리하기 위해 만든 delegate;
    // public delegate void CountdownChecker();
    // public static CountdownChecker turnChecker;

    // public Vector3 setupPos;
    public bool setupGo = false; // 폭탄이 마우스와 같이 돌아다니는가(설치 준비 중인가?)
    public bool hasTempBomb = false; // 현재 임시적으로 폭탄을 마우스 끝에 담고 있는가?

    public GameObject bObject;

    void Countdown()
    {

    }

    public void CreateBombtoButtonClick(Temp_Character _tempCharacter, bool _needSetupChance)
    {
        // bObject = Instantiate(_b.gameObject, setupPos, Quaternion.identity);
        //bObject = _tempCharacter.gameObject;
        bObject = _tempCharacter.gameObject;
        
        if (_needSetupChance && !setupGo)
        {
            setupGo = true;
        }
        // return bObject;

        
    }

    public void ReadytoSetup(Vector3 _hitPos)
    {
        if (!hasTempBomb)
        {
            bObject = Instantiate(bObject);
            hasTempBomb = true;
        }
        else
        {
            bObject.transform.position = new Vector3(_hitPos.x, 0, _hitPos.z);

            if (Input.GetMouseButtonDown(0))
            {
                setupGo = false;
                GameObject actualObj = bObject;

                Instantiate(actualObj);

                bObject.SetActive(false);
                hasTempBomb = false;
            }
        }
    }

    // Start is called before the first frame update
    // void Start()
    // {
    //     if (bombs.Count == 0)
    //     {
    //         // GameObject bomb = new GameObject("Primitive Bomb");
    //         //bomb.AddComponent<Bomb>();
    //         // bombs.Enqueue(bomb);
    //     }
    //     print(bombs.Count);
    // }

    // void Update()
    // {
    //     setupPos = battle.hit.point;

    //     if (setupGo)
    //     {
    //         ReadytoSetup();
    //     }
    // }

    // public void ReturnBombPosition(Bomb _b, Temp_Character _t, bool _needSetupChance) // 폭탄의 설치 유형, 현재 턴 캐릭터, 설치 가능 위치 등을 매개변수로 받음.
    // {
    //     Vector3 returnPos = Vector3.zero;

    //     if (_b.startSetPos == StartSetPos.Hand) //캐릭터 자신의 위치에 폭탄을 설치
    //     {
    //         SetBombinHand(_b, _t);
    //     }
    //     else if (_b.startSetPos == StartSetPos.Point) // 임의 지점에 폭탄을 설치
    //     {
    //         SetBombwithPoint(setupPos, _b);
    //     }
    // }

    // public void SetBombwithPoint(Vector3 _v, Bomb _b)
    // { // 폭탄 설치 시 Point를 통해 폭탄을 설치할 위치를 지정.

    //     GameObject b = CreateBombtoButtonClick(_b, _v);

    //     bool setEnd = false;

    //     if (b != null && !setEnd)
    //     {
    //         b.transform.position = new Vector3(_v.x, b.transform.localScale.y * 0.5f, _v.z);
    //     }
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         setEnd = true;
    //     }
    // }
}