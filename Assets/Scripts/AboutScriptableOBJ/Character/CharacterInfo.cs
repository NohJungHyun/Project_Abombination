using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassJob{Warrrior, Mage, Thief}
public enum ClassifyWhatisIt{Character, Object}
public enum CharacterType{Human, Construct}

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/CharacterMaking", order = 1)]
public class CharacterInfo : ScriptableObject
{
    #region 1. 캐릭터 기본 명시 사항 
    public ClassifyWhatisIt definition;
    public CharacterType characterType;

    public string characterName;
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

    public int currentHP;
    public int maxHP;
    #endregion

    #region 4. 캐릭터 능력치 변수로부터 Stat 적용.
    Stat statAttack;
    Stat statDefense;
    Stat statMove;
    Stat statCharisma;
    Stat statLuck;

    Stat throwRange; // 폭탄 던지기 거리
    public Stat statInitiative{get; set;}
    #endregion

    private void Awake()
    {
        statAttack = new Stat(characterAttack);
        statDefense = new Stat(characterDefense);
        statMove = new Stat(characterMovement);
        statCharisma = new Stat(characterCharisma);
        statLuck = new Stat(characterLuck);
        statInitiative = new Stat(characterInitiative);
        // Debug.Log(statInitiative.baseStat);
    }

    public void Die()
    {

    }

    public void TakeDamage(int dmg)
    {
        Debug.Log("피해를 입었다: " + dmg);
    }
    

}
