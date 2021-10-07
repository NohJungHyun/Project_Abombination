using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OccurrenceBox 
{
    public int occurSpeed;
    
    public bool isTakeTime;
    public int canUseNum;

    public bool isStack;
    public int maxStack;

    IEnumerator coroutine;
    
    OccurrenceTemplate occurrenceTemplate;

    Temp_Character owner;

    List<BattleOccur> battleOccurs = new List<BattleOccur>();
    List<CharacterOccur> characterOccurs = new List<CharacterOccur>();

    public OccurrenceBox(OccurrenceTemplate ot)
    {
        occurrenceTemplate = ot;
        Init(ot.occurSpeed, ot.isTakeTime, ot.canUseNum, ot.isStack, ot.maxStack);

        battleOccurs = occurrenceTemplate.battleOccurs;
        characterOccurs = occurrenceTemplate.characterOccurs;
    }

    public void Init(int _speed, bool _checkTakeTime, int _useNum, bool _checkStack, int _maxStack)
    {
        occurSpeed = _speed;

        isTakeTime = _checkTakeTime;
        canUseNum = _useNum;

        isStack = _checkStack;
        maxStack = _maxStack;
    }

    public void InvokeOccur(MonoBehaviour mono)
    {
        if(occurrenceTemplate.isInvokeOnlyMyTurn)
            if(NowTurnCharacterManager.nowPlayCharacter != owner)
                return;
        
        coroutine = occurrenceTemplate.InvokeOccur(mono, owner);
        mono.StartCoroutine(coroutine);
        Debug.Log("OccurrenceBox:" + owner.name);
    }

    public void ChangeOccurrenceTemplate(OccurrenceTemplate ot)
    {
        occurrenceTemplate = ot;
    }

    public void ChangeOccurSpeed(int speed)
    {
        occurSpeed = speed;
    }

    public void SetOwner(Temp_Character t)
    {
        owner = t;
    }

    public Temp_Character GetOwner()
    {
        return owner;
    }
}
