﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Character : MonoBehaviour, IDamageable
{
    public CharacterInfo characterInfo;

    public CharacterInfo info { get; set; }

    public bool canMove;
    public bool canActwithBomb;
    public bool canUseSkill;

    // 캐릭터가 설치가능한 폭발물 리스트
    public List<Explosion> canSetExplosions = new List<Explosion>(6);
    // 캐릭터가 설치가능한 폭탄 리스트
    public List<Bomb> canSetBombs = new List<Bomb>(6);
    public List<Bomb> haveBombs = new List<Bomb>(6);

    public List<ItemData> haveItems = new List<ItemData>(6);
    public List<SkillData> haveSkills = new List<SkillData>(6);

    Vector3 basicPos;

    public int actionPoint;

    float canWalkDist; // 캐릭터가 월드 상에서 이동할 수 있는 거리를 의미. 캐릭터의 movement와 적절히 계산되어 산출되며, 이동 가능 반경을 이동할 때마다 감소한다.

    // 버프 List 제작 
    // 장비 List 제작
    // 스킬 List 제작

    void Start()
    {
        info = Instantiate(characterInfo);

        this.actionPoint = info.maxActionPoint;

        for (int b = 0; b < canSetBombs.Count; b++)
        {
            canSetBombs[b] = Instantiate(canSetBombs[b]);

            canSetBombs[b].bombOwner = this;
        }

        for (int h = 0; h < haveBombs.Count; h++)
        {
            haveBombs[h] = ScriptableObject.Instantiate(haveBombs[h]);
            haveBombs[h].SetCountDown();
            // Debug.Log("가지고 있는 폭탄의 이름: " + haveBombs[h].bombName + ", " + "가지고 있는 폭탄의 카운트 다운: " + haveBombs[h].bombCurCountDown);
            // 전투 시작 때 가지고 있으니 자기 꺼라 하자. 
            haveBombs[h].attachedTarget = this;

            if (!haveBombs[h].bombOwner)
            {
                haveBombs[h].bombOwner = this;
            }

            if (haveBombs[h].GetExplosionsList().Count > 0)
            {
                for (int e = 0; e < haveBombs[h].GetExplosionsList().Count; e++)
                {
                    haveBombs[h].GetExplosionsList()[e].GetRidOfExplosionAllEvent(haveBombs[h]);
                    haveBombs[h].GetExplosionsList()[e].SetExplosionAllEvent(haveBombs[h]);
                }
            }
        }

        for (int e = 0; e < canSetExplosions.Count; e++)
        {
            canSetExplosions[e] = ScriptableObject.Instantiate(canSetExplosions[e]);
            canSetExplosions[e].explosionOwner = this;
        }
        basicPos = transform.position;
    }

    public List<Bomb> GetCanSetBombs()
    {
        return canSetBombs;
    }
    public List<Bomb> GetHaveBombs()
    {
        return haveBombs;
    }

    public List<Explosion> GetCanSetExplosions()
    {
        return canSetExplosions;
    }
    public void AddBombtoHaveBombs(Bomb _b, int _p)
    {
        haveBombs.Insert(_p, _b);
    }

    public void AddBombtoCanSetBombs(Bomb _b, int _p)
    {
        canSetBombs.Insert(_p, _b);
    }

    public void RemoveBombtoHaveBombs(Bomb _b)
    {
        if (haveBombs.Equals(_b))
        {
            haveBombs.Remove(_b);
        }
    }

    public void RemoveBombtoCanSetBombs(Bomb _b)
    {
        if (canSetBombs.Equals(_b))
        {
            canSetBombs.Remove(_b);
        }
    }

    public void TakeDamage(int _dmg)
    {
        Debug.Log("피해를 입었다: " + _dmg);

        info.currentHP -= _dmg;
        if (info.currentHP <= 0)
            Dead();
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
        return haveItems;
    }

    public List<SkillData> GetHaveSkills()
    {
        return haveSkills;
    }
}