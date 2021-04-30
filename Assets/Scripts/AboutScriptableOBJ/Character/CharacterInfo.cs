using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClassJob { Warrrior, Mage, Thief }
public enum ClassifyWhatisIt { Character, Object }
public enum CharacterType { Human, Construct }

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/CharacterMaking", order = 1)]
public class CharacterInfo : ScriptableObject
{
    #region 1. 캐릭터 기본 명시 사항 
    public ClassifyWhatisIt definition;
    public CharacterType characterType;

    public string characterName;
    //public Sprite characterImage;
    public Sprite characterImage;
    public GameObject characterModel;
    #endregion

    #region 2. 캐릭터 성장 관련 변수
    public int chracterLevel;
    public ClassJob characterClass;
    public float characterexp;
    #endregion

    #region 3. 캐릭터 능력치 관련 변수
    public int characterAttack;
    public int characterDefense;
    public int characterMovement;
    public int characterCharisma;
    public int characterLuck;
    public int characterInitiative;

    public int characterDetectRange;
    public int characterThrowRange;

    public int currentHP;
    public int maxHP;

    public int curActionPoint;
    public int maxActionPoint;
    public int minActionPoint;

    public int needCommandPoint;
    #endregion

    #region 4. 캐릭터 능력치 변수로부터 Stat 적용.
    Stat statAttack;
    Stat statDefense;
    Stat statMove;
    Stat statCharisma;
    Stat statLuck;

    Stat statThrowRange; // 폭탄 던지기 거리

    public Stat statInitiative { get; set; }
    #endregion

    private void Awake()
    {
        statAttack = new Stat(characterAttack);
        statDefense = new Stat(characterDefense);
        statMove = new Stat(characterMovement);
        statCharisma = new Stat(characterCharisma);
        statLuck = new Stat(characterLuck);
        statInitiative = new Stat(characterInitiative);
        statThrowRange = new Stat(characterThrowRange);

        currentHP = maxHP;
        curActionPoint = maxActionPoint;
    }

    public void TakeDamage(int _dmg)
    {
        Debug.Log("피해를 입었다: " + _dmg);
        currentHP -= _dmg;
        if (currentHP <= 0)
            Dead();
    }

    public void Dead()
    {
        Debug.Log("끄앙 주금");
    }

    public void SetActionPoint(int _AP, int _distinguishNum)
    {
        switch (_distinguishNum)
        {
            case 0: // 합 연산, 빼기 연산
                if (curActionPoint + _AP <= maxActionPoint)
                    curActionPoint += _AP;
                else
                    curActionPoint = maxActionPoint;
                break;
            case 1: // 숫자 적용 연산
                curActionPoint = _AP;
                break;
        }
    }

    public void SpendActionPoint(int _spendAP)
    {
        curActionPoint -= _spendAP;
        if (curActionPoint - _spendAP < 0)
        {
            Debug.Log("AP가 부족하여 사용불가");
        }
    }
}
