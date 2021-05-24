﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterEventBox))]
public class Temp_Character : MonoBehaviour, IDamageable
{
    [SerializeField]
    CharacterInfo characterInfo;

    CharacterInfo info { get; set; }

    public bool canMove;
    public bool canActwithBomb;
    public bool canUseSkill;

    Vector3 basicPos;

    public int actionPoint;
    public int curHP;

    float canWalkDist; // 캐릭터가 월드 상에서 이동할 수 있는 거리를 의미. 캐릭터의 movement와 적절히 계산되어 산출되며, 이동 가능 반경을 이동할 때마다 감소한다.

    public delegate void CharacterDelegate();
    public event CharacterDelegate UpdateDelegate;
    public event CharacterDelegate TurnStartDelegate;
    public event CharacterDelegate TakeDamageDelegate;
    public event CharacterDelegate TurnEndDelegate;


    void Start()
    {
        info = Instantiate(characterInfo);
        info.SetBasic();

        curHP = info.maxHP;

        this.actionPoint = info.maxActionPoint;

        for (int b = 0; b < characterInfo.canSetBombs.Count; b++)
        {
            info.canSetBombs[b] = ScriptableObject.Instantiate(characterInfo.canSetBombs[b]);

            info.canSetBombs[b].SetOwner(this);
        }

        for (int h = 0; h < characterInfo.haveBombs.Count; h++)
        {
            info.haveBombs[h] = ScriptableObject.Instantiate(characterInfo.haveBombs[h]);
            info.haveBombs[h].SetCountDown();

            // 전투 시작 때 가지고 있으니 자기 꺼라 하자. 
            info.haveBombs[h].SetAttachedTarget(this);

            if (!characterInfo.haveBombs[h].GetOwner())
            {
                info.haveBombs[h].SetOwner(this);
            }

            if (characterInfo.haveBombs[h].GetExplosionsList().Count > 0)
            {
                for (int e = 0; e < characterInfo.haveBombs[h].GetExplosionsList().Count; e++)
                {
                    // info.haveBombs[h].GetExplosionsList()[e].GetRidOfExplosionAllEvent(characterInfo.haveBombs[h]);
                    info.haveBombs[h].GetExplosionsList()[e].SetExplosionAllEvent(info.haveBombs[h]);
                }
            }
        }

        for (int e = 0; e < characterInfo.canSetExplosions.Count; e++)
        {
            info.canSetExplosions[e] = ScriptableObject.Instantiate(characterInfo.canSetExplosions[e]);
            info.canSetExplosions[e].SetOwner(this);
        }

        basicPos = transform.position;
    }

    public List<Bomb> GetCanSetBombs()
    {
        return info.canSetBombs;
    }
    public List<Bomb> GetHaveBombs()
    {
        return info.haveBombs;
    }

    public List<Explosion> GetCanSetExplosions()
    {
        return info.canSetExplosions;
    }
    public void AddBombtoHaveBombs(Bomb _b, int _p)
    {
        info.haveBombs.Insert(_p, _b);
    }

    public void AddBombtoCanSetBombs(Bomb _b, int _p)
    {
        info.canSetBombs.Insert(_p, _b);
    }

    public void RemoveBombtoHaveBombs(Bomb _b)
    {
        if (info.haveBombs.Equals(_b))
        {
            info.haveBombs.Remove(_b);
        }
    }

    public void RemoveBombtoCanSetBombs(Bomb _b)
    {
        if (info.canSetBombs.Equals(_b))
        {
            info.canSetBombs.Remove(_b);
        }
    }

    public void TakeDamage(int _dmg)
    {
        Debug.Log(this.name + "가 피해를 입었다: " + _dmg);

        info.currentHP -= _dmg;
        curHP -= _dmg;
        if (info.currentHP <= 0)
            Dead();
    }

    public void TakeHeal(int _heal)
    {
        Debug.Log(this.name + "가 체력을 회복하였다: " + _heal);

        if (curHP >= curHP + _heal)
            curHP = curHP + _heal;
        else
        {
            info.currentHP += _heal;
            curHP += _heal;
        }

    }

    public void Dead()
    {
        Debug.Log("끄앙 주금");
        this.gameObject.SetActive(false);
    }

    public Vector3 GetCharacterPos()
    {
        return this.transform.position;
    }

    public void SetCharacterPos(Vector3 _pos)
    {
        this.transform.position = _pos;
    }

    public void LookMousePos(bool _canRotate)
    {
        if (!_canRotate) return;

        Vector3 lookPos = new Vector3(SearchWithRayCast.GetHitPoint().x, transform.position.y, SearchWithRayCast.GetHitPoint().z);
        transform.LookAt(lookPos);
    }

    public void SubtractActionPoint(int _point)
    {
        actionPoint -= _point;
    }

    public void AddActionPoint(int _point)
    {
        actionPoint += _point;
    }

    public void SetActionPoint(int _point)
    {
        actionPoint = _point;
    }

    public int GetActionPoint()
    {
        return actionPoint;
    }

    public void ResetActionPoint()
    {
        actionPoint = info.maxActionPoint;
    }

    public List<ItemData> GetHaveItems()
    {
        return characterInfo.haveItems;
    }

    public List<SkillData> GetHaveSkills()
    {
        return characterInfo.haveSkills;
    }

    public void AddEventBox(int _idx, EventBox _eb)
    {
        characterInfo.characterEventBox.Add(_idx, _eb);
    }

    public void RemoveEventBox(int _idx)
    {
        if (characterInfo.characterEventBox.ContainsKey(_idx) && characterInfo.characterEventBox[_idx] == null)
            characterInfo.characterEventBox.Remove(_idx);
    }

    public CharacterInfo GetCharacterInfo()
    {
        return this.info;
    }

    public void SetCurInfoToDraft()
    {
        characterInfo = info;
    }

    public List<ActiveItem> GetPreparedItems()
    {
        return info.preparedItems;
    }
    public List<ActiveSkill> GetPreparedSkills()
    {
        return info.preparedSkills;
    }
}