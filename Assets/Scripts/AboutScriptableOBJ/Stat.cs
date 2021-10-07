using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatCheck
{
    public int way;
    public float num;
    public int order;

    //어떻게 스탯을 조정할 것인지 사전에 정의, 정렬한 뒤에 적용하기 위해 만든 클래스.

    public StatCheck(float _num, int _order, int _way = 999)
    {
        this.num = _num;
        this.order = _order;
        this.way = _way;
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

    // public void CreateStatContents(float _num, int _order = 999)
    // {
    //     StatCheck _sc = new StatCheck(_num, _order);
    //     adjustedModifiers.Insert(_sc.order, _sc);
    //     CalculateResult(_sc);
    // }

    public void CalculateResult(StatCheck sc) //본격적인 계산을 진행하는 공간.
    {
        // 0: Plus / 1: minus / 2: multiple / else: set

        if (adjustedModifiers.Count > 0)
        {
            for (int i = 0; i < adjustedModifiers.Count; i++)
            {
                if (sc.way == 0) //Plus
                    resultStat += (int)sc.num;
                else if (sc.way == 1)
                    resultStat -= (int)sc.num;
                else if (sc.way == 2)
                    resultStat *= (int)sc.num;
                else
                    resultStat = (int)sc.num;
            }
        }
    }

    public void SetAddStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order, 0);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count, _sc.order), _sc);
        CalculateResult(_sc);
    }

    public void SetSubtractStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order, 1);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count,_sc.order), _sc);
        CalculateResult(_sc);
    }

    public void SetMultipleStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order,2);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count,_sc.order), _sc);
        CalculateResult(_sc);
    }

    public void SetResultNum(float _num)
    {
        resultStat = (int)_num;
    }
}
