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
    // public BattleController battleController;

    // 턴, 라운드가 진행될 때마다 카운트 다운되는 걸 계산, 처리하기 위해 만든 delegate;
    public delegate void CountdownChecker();
    public static CountdownChecker turnChecker;

    public Vector3 setupPos;

    // Start is called before the first frame update
    void Start()
    {
        if (bombs.Count == 0)
        {
            GameObject bomb = new GameObject("Primitive Bomb");
            //bomb.AddComponent<Bomb>();
            bombs.Enqueue(bomb);
        }
        // print(bombs.Count);
    }


    void Countdown()
    {

    }

    public void ReturnBombPosition(Bomb _b, Temp_Character _t) // 폭탄의 설치 유형, 현재 턴 캐릭터, 설치 가능 위치 등을 매개변수로 받음.
    {
        Vector3 returnPos = Vector3.zero;

        if (_b.startSetPos == StartSetPos.Hand) //캐릭터 자신의 위치에 폭탄을 설치
        {
            SetBombinHand(_b, _t);
        }
        else if (_b.startSetPos == StartSetPos.Point) // 임의 지점에 폭탄을 설치
        {
            SetBombwithPoint(setupPos, _b);
        }
    }

    public GameObject CreateBombtoButtonClick(Bomb _b)
    {
        GameObject bombObj = Instantiate(_b.bombObject) as GameObject;
        //ReturnBombPosition(bombObj, _t);

        return bombObj;
    }

    public void SetBombwithPoint(Vector3 _v, Bomb _b)
    { // 폭탄 설치 시 Point를 통해 폭탄을 설치할 위치를 지정.

        GameObject b = CreateBombtoButtonClick(_b);
        bool setEnd = false;
        if (b != null && !setEnd)
        {
            b.transform.position = new Vector3(_v.x, b.transform.localScale.y * 0.5f, _v.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            setEnd = true;
        }
    }

    public void SetBombinHand(Bomb _b, Temp_Character _t){
        _t.haveBombs.Add(_b);
        CreateBombtoButtonClick(_b).transform.SetParent(_t.transform);
    }

    public void GetHitPoint(Vector3 _h){
        setupPos = _h;
    }
}