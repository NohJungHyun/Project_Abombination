using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participants : MonoBehaviour
{
    protected BattleParticipantsManager battleParticipantsManager;
    protected NowTurnCharacterManager nowTurnCharacterManager;

    public int maxCommandPoint;
    public int curCommandPoint;

    public bool canControl; 

    public List<Temp_Character> haveCharacters = new List<Temp_Character>();

    public virtual void Init()
    {
        ResetCommandPoint();
    }

    void Start()
    {
        battleParticipantsManager = FindObjectOfType<BattleParticipantsManager>();
        nowTurnCharacterManager = battleParticipantsManager.GetComponent<NowTurnCharacterManager>();

        ResetCommandPoint();
        SeperateParticipant();
    }

    public void ResetCommandPoint()
    {
        curCommandPoint = maxCommandPoint;
    }

    public bool AdjustPoint(bool _isAdd, int _num)
    {
        if (_num > curCommandPoint)
            return false;

        if (_isAdd)
            curCommandPoint += _num;
        else
            curCommandPoint -= _num;

        if (curCommandPoint < 0)
            curCommandPoint = 0;

        return true;
    }

    public bool allCharacterDie()
    {
        for(int i = 0; i < haveCharacters.Count; i++)
        {
            if(haveCharacters[i].isActiveAndEnabled)
                return false;
        }

        return true;
    }

    void SeperateParticipant()
    {
        Debug.Log(this.name + ": " + haveCharacters.Count);

        for (int i = 0; i < haveCharacters.Count; i++)
        {
            haveCharacters[i].SetParticipants(this);
        }
    }
}
