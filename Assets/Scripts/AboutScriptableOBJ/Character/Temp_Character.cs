﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Character : MonoBehaviour
{
    public CharacterInfo characterInfo;

    public CharacterInfo info { get; set; }

    public bool canMove;
    public bool canActwithBomb;
    public bool canUseSkill;

    // 캐릭터가 설치가능한 폭발물 리스트
    public List<Explosion> canSetExplosions = new List<Explosion>(30);
    // 캐릭터가 설치가능한 폭탄 리스트
    public List<Bomb> canSetBombs = new List<Bomb>(10);
    public List<Bomb> haveBombs = new List<Bomb>(10);

    Vector3 basicPos;

    float canWalkDist; // 캐릭터가 월드 상에서 이동할 수 있는 거리를 의미. 캐릭터의 movement와 적절히 계산되어 산출되며, 이동 가능 반경을 이동할 때마다 감소한다.

    // 버프 List 제작 
    // 장비 List 제작
    // 스킬 List 제작

    void Start()
    {
        info = Instantiate(characterInfo);

        for (int b = 0; b < canSetBombs.Count; b++)
        {
            canSetBombs[b] = Instantiate(canSetBombs[b]);
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(basicPos, info.characterMovement);

        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, info.characterDetectRange);

        Gizmos.DrawLine(transform.position, SearchWithRayCast.GetHitPoint());
    }

}