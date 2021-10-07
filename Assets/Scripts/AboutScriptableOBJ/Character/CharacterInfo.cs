using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClassJob { Warrrior, Mage, Thief }
public enum ClassifyType { Character, Object }
public enum CharacterType { Human, Construct }

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/CharacterMaking", order = 1)]
public class CharacterInfo : NeedPlayerThings
{
    #region 1. 캐릭터 기본 명시 사항 
    public ClassifyType definitionType;
    public CharacterType characterType;

    public GameObject characterModel;
    #endregion

    #region 2. 캐릭터 성장 관련 변수
    public ClassJob characterClass;
    public int chracterLevel;
    
    public int characterExp;
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

    public int maxHP;

    public int curActionPoint;
    public int maxActionPoint;
    public int minActionPoint;

    public int needCommandPoint;

    public float curMoveAreaRadius;
    public float maxMoveAreaRadius;
    public float minMoveAreaRadius;
    public float moveAreaShrinkRate;

    // 캐릭터가 설치가능한 폭발물 리스트
    public List<Explosion> canSetExplosions = new List<Explosion>(6);
    // 캐릭터가 설치가능한 폭탄 리스트
    public List<BombData> canSetBombs = new List<BombData>(6);
    public List<BombData> haveBombs = new List<BombData>(6);

    public List<ItemData> haveItems = new List<ItemData>();
    public List<SkillData> haveSkills = new List<SkillData>();

    public List<ActiveItem> preparedItems = new List<ActiveItem>(6);
    public List<ActiveSkill> preparedSkills = new List<ActiveSkill>(6);

    #endregion

    // #region 4. 캐릭터 능력치 변수로부터 Stat 적용.
    // Stat statAttack;
    // Stat statDefense;
    // Stat statMove;
    // Stat statCharisma;
    // Stat statLuck;

    // Stat statThrowRange; // 폭탄 던지기 거리
    // Stat statDetectRange;

    // Stat statInitiative;
    // #endregion

    // public void SetBasic()
    // {
    //     statAttack = new Stat(characterAttack);
    //     statDefense = new Stat(characterDefense);
    //     statMove = new Stat(characterMovement);
    //     statCharisma = new Stat(characterCharisma);
    //     statLuck = new Stat(characterLuck);
    //     statInitiative = new Stat(characterInitiative);
    //     statThrowRange = new Stat(characterThrowRange);

    //     currentHP = maxHP;
    //     curActionPoint = maxActionPoint;
    // }

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
            Debug.Log("AP가 부족하여 사용불가");
        
    }
}
