using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OccurTiming{Passive, UpdateTiming, StartTiming, EndTiming};
public enum OccurBattleState{BattleStart, BattleEnd, BattleWin, BattleLose, RoundStart, RoundEnd, PhaseStart, PhaseEnd, 
    SelectCharacter, CharacterTurnStart, characterTurnDo, characterTurnEnd}
public enum OccurCharacterState{WaitOrder, Move, ModifyCountdown, UseSkill, UseItem, SelectTarget, CreateBomb, DiffuseBomb, BoomBomb, AddExplosion, RemoveExplosion, RunBattle}

// [CreateAssetMenu(menuName = "ScriptableObjects/new OccurrenceTemplate")]
public abstract class OccurrenceTemplate : NeedOwnerThings
{
    List<Temp_Character> targets = new List<Temp_Character>();

    public int occurSpeed;

    public bool isTakeTime;
    public int canUseNum;

    public bool isStack;
    public int maxStack;
    public int occurInterval; // -1이면 없음
    public bool isInvokeOnlyMyTurn;

    public List<BattleOccur> battleOccurs = new List<BattleOccur>();
    public List<CharacterOccur> characterOccurs = new List<CharacterOccur>(); 

    public abstract IEnumerator InvokeOccur(MonoBehaviour mono, Temp_Character temp_Character);
    protected abstract IEnumerator OccurContent(Temp_Character t);

    public void SetTargets(List<Temp_Character> characters)
    {
        targets = characters;
    }

    public void SetTarget(Temp_Character character)
    {
        if(!targets.Contains(character))
            targets.Add(character);
    }

    public void RemoveCharacter(Temp_Character character)
    {
        if(targets.Contains(character))
            targets.Remove(character);
    }

    public void ResetTargets()
    {
        targets.Clear();
    }

    // public void SpreadtoCharacterContainer()
    // {
    //     if(characterOccurs.Count < 1) return;

    //     for(int co = 0; co < characterOccurs.Count; co++)
    //     {
    //         OccurrenceBox newBox = new OccurrenceBox(this);
    //         switch (characterOccurs[co].occurCharacterState)
    //         {
    //             case OccurCharacterState.WaitOrder:
    //                 Character.Add(newBox);
    //                 continue;
    //             case OccurCharacterState.Move:
    //                 BattleOccurrenceContainer.instance.battleStartContainer.Add(newBox);
    //                 continue;
    //                 case OccurCharacterState.WaitOrder:
    //                 BattleOccurrenceContainer.instance.battleStartContainer.Add(newBox);
    //                 continue;
    //         }
                
    //     }
    // }

    public void SpreadtoBattleContainer(Temp_Character t)
    {
        if(battleOccurs.Count < 1) return;

        for(int bo = 0; bo < battleOccurs.Count; bo++)
        {
            OccurrenceBox newBox = new OccurrenceBox(this);
            newBox.SetOwner(t);
            switch (battleOccurs[bo].occurBattleState)
            {
                case OccurBattleState.BattleStart:
                    BattleOccurrenceContainer.instance.battleStartContainer.Add(newBox);
                    continue;
                case OccurBattleState.BattleEnd:
                    BattleOccurrenceContainer.instance.battleEndContainer.Add(newBox);
                    continue;
                case OccurBattleState.BattleWin:
                    BattleOccurrenceContainer.instance.battleWinContainer.Add(newBox);
                    continue;
                case OccurBattleState.BattleLose:
                    BattleOccurrenceContainer.instance.battleLoseContainer.Add(newBox);
                    continue;
                case OccurBattleState.RoundStart:
                    BattleOccurrenceContainer.instance.roundStartContainer.Add(newBox);
                    continue;
                case OccurBattleState.RoundEnd:
                    BattleOccurrenceContainer.instance.roundEndContainer.Add(newBox);
                    continue;
                case OccurBattleState.PhaseStart:
                    BattleOccurrenceContainer.instance.phaseStartContainer.Add(newBox);
                    continue;
                case OccurBattleState.PhaseEnd:
                    BattleOccurrenceContainer.instance.phaseEndContainer.Add(newBox);
                    continue;
                case OccurBattleState.SelectCharacter:
                    BattleOccurrenceContainer.instance.selectChracterContainer.Add(newBox);
                    continue;
                case OccurBattleState.CharacterTurnStart:
                    BattleOccurrenceContainer.instance.playerTurnStartContainer.Add(newBox);
                    continue;
                case OccurBattleState.characterTurnDo:
                    BattleOccurrenceContainer.instance.playerTurnDoContainer.Add(newBox);
                    continue;
                case OccurBattleState.characterTurnEnd:
                    BattleOccurrenceContainer.instance.playerTurnEndContainer.Add(newBox);
                    continue;
            }
        }
    }
}

[System.Serializable]
public class BattleOccur
{
    public OccurBattleState occurBattleState;
    public OccurTiming occurTiming;
}

[System.Serializable]
public class CharacterOccur
{
    public OccurCharacterState occurCharacterState;
    public OccurTiming occurTiming;
}
