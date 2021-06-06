using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participants : MonoBehaviour
{
    public BattleController battleController;
    public int maxCommandPoint;
    public int curCommandPoint;

    public List<Temp_Character> haveCharacters = new List<Temp_Character>();


    public SelectCharacterUI selectCharacterUI;

    // Start is called before the first frame update
    void Start()
    {
        battleController = FindObjectOfType<BattleController>();
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
