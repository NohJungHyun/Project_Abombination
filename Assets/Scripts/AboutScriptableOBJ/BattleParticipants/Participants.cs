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


    public SelectCharacterUI selectCharacterUI;

    public virtual void Init()
    {
        Debug.Log("나의 턴! " + this.name);
        ResetCommandPoint();
    }

    void Start()
    {
        battleParticipantsManager = FindObjectOfType<BattleParticipantsManager>();
        nowTurnCharacterManager = battleParticipantsManager.GetComponent<NowTurnCharacterManager>();
        
        ResetCommandPoint();
    }

    void ResetCommandPoint()
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
}
