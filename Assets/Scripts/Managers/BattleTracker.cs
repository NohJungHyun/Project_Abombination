using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTracker : MonoBehaviour
{
    public static BattleTracker instance;
    public int battleRound = 0; // 배틀 경과 라운드
    public int battleTurn = 0; // 배틀 경과 턴

    public int index = 0; // 현재 선택된 캐릭터를 측정하기 위해 사용되는 카운터.

    public delegate void ChangeDele();
    public static event ChangeDele ChangeTurn;
    public static event ChangeDele ChangeRound;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    void Start()
    {
        ChangeTurn += MoveToNextTurn;
        ChangeRound += MoveToNextRound;
    }

    public void SetBattleTurn(int _turnNum)
    {
        battleTurn = _turnNum;
    }
    public int GetBattleTurn()
    {
        return battleTurn;
    }
    public void SetBattleRound(int _roundNum)
    {
        battleRound = _roundNum;
    }

    public int GetBattleRound()
    {
        return battleRound;
    }

    // 다음 라운드
    public void MoveToNextRound()
    {
        battleRound++;
    }

    public void MoveToNextTurn()
    {
        battleTurn++;
    }
}
