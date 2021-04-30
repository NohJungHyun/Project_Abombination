using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxCommandPoint;
    public int curCommandPoint;

    public List<Temp_Character> playerCharacters = new List<Temp_Character>(10);

    public SelectCharacterUI selectCharacterUI;

    // Start is called before the first frame update
    void Start()
    {
        ResetCommandPoint();
    }

    void ResetCommandPoint()
    {
        curCommandPoint = maxCommandPoint;
    }

    public void AdjustPoint(bool _isAdd, int _num)
    {
        if(_num > curCommandPoint) return;

        if(_isAdd)
            curCommandPoint += _num;
        else    
            curCommandPoint -= _num;

        if(curCommandPoint < 0)
            curCommandPoint = 0;

        selectCharacterUI.CountCommandPoints(_num);
    }
}
