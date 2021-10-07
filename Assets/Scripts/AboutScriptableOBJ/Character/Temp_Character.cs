﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Character : MonoBehaviour, IDamageable
{
    [SerializeField]
    CharacterInfo characterInfo;

    CharacterInfo info
    {
        get { return characterInfo; }
        set 
        {
            if(value != characterInfo)
            {
                characterInfo = value;
                Init();
            }
        }
    }

    public Participants controller;

    public bool canMove;
    public bool canActWithBomb;
    public bool canUseSkill;

    Vector3 basicPos;

    public int curHP;
    public int CurrentHP { get { return curHP; } }
    public float curMoveAreaRadius;

    // public GameObject rangeMeshObj;
    public ConeRangeMesh rangeMesh;

    SkillContainer skillContainer;
    ItemContainer itemContainer;
    StatContainer statContainer;
    ActionPointController actionPointController;
    CanSetBombsContainer canSetBombsContainer;
    CarriedBombContainer carriedBombContainer;
    CharacterMoveAreaController characterMoveAreaController;
    ExplosionContainer explosionContainer;

    public SkillContainer SkillContainer { get { return skillContainer; } }
    public ItemContainer ItemContainer { get { return itemContainer; } }

    public StatContainer StatContainer { get { return statContainer; } }
    public ActionPointController ActionPointController { get { return actionPointController; } }
    public CanSetBombsContainer CanSetBombsContainer { get { return canSetBombsContainer; } }
    public CarriedBombContainer CarriedBombContainer { get { return carriedBombContainer; } }
    public CharacterMoveAreaController CharacterMoveAreaController { get { return characterMoveAreaController; } }
    public ExplosionContainer ExplosionContainer { get { return explosionContainer; } }

    private void Awake()
    {
        info = Instantiate(characterInfo);
        Init();
    }

    void Start()
    {
        basicPos = transform.position;
        curHP = info.maxHP;

        rangeMesh = GetComponentInChildren<ConeRangeMesh>();
        // rangeMesh.enabled = false;
        // if (rangeMeshObj != null && nowPlayCharacter)
        //     rangeMeshObj.transform.position = nowPlayCharacter.transform.position;
    }

    public void Init()
    {
        skillContainer = new SkillContainer(info, this);
        itemContainer = new ItemContainer(info, this);
        statContainer = new StatContainer(info, this);
        actionPointController = new ActionPointController(info, this);
        canSetBombsContainer = new CanSetBombsContainer(info, this);
        carriedBombContainer = new CarriedBombContainer(info, this);
        characterMoveAreaController = new CharacterMoveAreaController(info, this);
        explosionContainer = new ExplosionContainer(info, this);
    }

    public Vector3 GetCharacterPos()
    {
        return this.transform.position;
    }

    public Vector3 GetBasicPos()
    {
        return basicPos;
    }

    public void TakeDamage(int _dmg)
    {
        Debug.Log(this.name + "가 피해를 입었다: " + _dmg);

        curHP -= _dmg;
        if (curHP <= 0)
            Dead();
    }

    public void TakeHeal(int _heal)
    {
        Debug.Log(this.name + "가 체력을 회복하였다: " + _heal);

        if (curHP >= curHP + _heal)
            curHP = curHP + _heal;
        else
            curHP += _heal;
    }

    public void Dead()
    {
        info.Dead();
        print(gameObject.name + "이가 죽었다!");
        this.gameObject.SetActive(false);
    }

    public CharacterInfo GetCharacterInfo()
    {
        return this.info;
    }

    public void SetCurInfoToDraft()
    {
        characterInfo = info;
    }

    public void SetParticipants(Participants p)
    {
        controller = p;
    }

    public Participants GetParticipants()
    {
        return controller;
    }

    public void TurnOnMesh(bool isOn)
    {
        if (rangeMesh != null)
            rangeMesh.enabled = isOn;
        // if (rangeMeshObj != null)
        //     rangeMeshObj.SetActive(isOn);
    }

    public void TurnOnRangeMesh()
    {
        // rangeMesh = GetComponentInChildren<ConeRangeMesh>();
        // rangeMeshObj = rangeMesh.gameObject;
        rangeMesh.CreateMesh();
    }

    public List<Transform> GetVisibleTargets()
    {
        return rangeMesh.GetVisibleTargets();
    }
}