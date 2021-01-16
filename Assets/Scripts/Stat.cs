using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatCheck
{
    public int way;
    public float num;
    public int order;

    //어떻게 스탯을 조정할 것인지 사전에 정의, 정렬한 뒤에 적용하기 위해 만든 클래스.

    public StatCheck(int _way, float _num, int _order)
    {
        this.way = _way;
        this.num = _num;
        this.order = _order;
    }
}

// [CreateAssetMenu(fileName = "New Stat", menuName = "ScriptableObjects/StatMaking", order = 2)]
public class Stat
{
    //캐릭터에게 적용할 스탯을 의미.
    [SerializeField]
    public int baseStat;
    [SerializeField]
    public int resultStat;

    [SerializeField]
    List<StatCheck> adjustedModifiers = new List<StatCheck>();

    public Stat(int bStat)
    { //초기 스탯 선언 시 기본값을 설정하는 용도로 사용.  
        this.baseStat = bStat;
        resultStat = baseStat;
    }

    public int ShowResultStat()
    {   // 혹시 모를 값 표현 함수
        // 라고 누군가는 그렇게 생각을 했겠지...
        return resultStat;
    }

    public void CheckCal(int _way, float _num, int _order) //받아온 값들을 기반으로 adjustedModifiers에 넣을 순서, 값 등을 파악하고 Statcheck로 만들어 집어넣는다.
    {
        StatCheck _sc = new StatCheck(_way, _num, _order);
        adjustedModifiers.Insert(_sc.order, _sc);
        CalculateResult(_sc);
    }

    public void CalculateResult(StatCheck sc) //본격적인 계산을 진행하는 공간.
    {
        if (adjustedModifiers.Count > 0)
        {
            if (sc.way == 0) //Plus
            {
                resultStat += (int)sc.num;
            }
            else
            {
                resultStat = (int)(sc.num * resultStat);
            }
        }
    }
}
