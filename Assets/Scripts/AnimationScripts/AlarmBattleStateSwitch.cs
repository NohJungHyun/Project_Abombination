using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmBattleStateSwitch : BaseUIStorage
{
    Text changeText;
    Animation moveUIAnimation;

    private void Start() 
    {
        changeText = GetComponentInChildren<Text>();    
        moveUIAnimation = GetComponentInChildren<Animation>();
    }

    public void CallAnimation(string stateString)
    {
        ChangeText(stateString);
        moveUIAnimation.Play();
    }

    private void ChangeText(string stateString)
    {
        changeText.text = stateString;
    }
}
