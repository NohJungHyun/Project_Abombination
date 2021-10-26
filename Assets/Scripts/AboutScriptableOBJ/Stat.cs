using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatCheck
{
    public int way;
    public float num;
    public int order;

    //어떻게 스탯을 조정할 것인지 사전에 정의, 정렬한 뒤에 적용하기 위해 만든 클래스.

    public StatCheck(float _num, int _order = 999, int _way = 0)
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

    public void CalculateResult() //본격적인 계산을 진행하는 공간.
    {
        // 0: Plus / 1: minus / 2: multiple / else: set
        int result = baseStat;
        if (adjustedModifiers.Count > 0)
        {
            for (int i = 0; i < adjustedModifiers.Count; i++)
            {
                if (adjustedModifiers[i].way == 0) //Plus
                    result += (int)adjustedModifiers[i].num;
                else if (adjustedModifiers[i].way == 1)
                    result -= (int)adjustedModifiers[i].num;
                else if (adjustedModifiers[i].way == 2)
                    result *= (int)adjustedModifiers[i].num;
                else
                    result = (int)adjustedModifiers[i].num;
            }
        }

        resultStat = result;
    }

    public void SetAddStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order, 0);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count, _sc.order), _sc);
        CalculateResult();
    }

    public void SetSubtractStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order, 1);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count,_sc.order), _sc);
        CalculateResult();
    }

    public void SetMultipleStatContents(float _num, int _order = 999)
    {
        StatCheck _sc = new StatCheck(_num, _order,2);
        adjustedModifiers.Insert(Mathf.Min(adjustedModifiers.Count,_sc.order), _sc);
        CalculateResult();
    }

    public void AddStatCheck(StatCheck statCheck)
    {
        if(statCheck.order != 999)
            adjustedModifiers.Insert(statCheck.order,statCheck);
        else
            adjustedModifiers.Add(statCheck);
        CalculateResult();
    }

    public void RemoveStatCheck(StatCheck statCheck)
    {
        if(adjustedModifiers.Contains(statCheck))
            adjustedModifiers.Remove(statCheck);
        else
            Debug.Log("그런 거 없다!");

        CalculateResult();
    }

    public void SetResultNum(float _num)
    {
        resultStat = (int)_num;
    }
}
