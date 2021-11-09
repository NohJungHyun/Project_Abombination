using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmBattleStateSwitch : BaseUIStorage
{
    [SerializeField]
    Text changeText;
    [SerializeField]
    Animation moveUIAnimation;

    void OnEnable()
    {
        
        Init();
    }

    private void Init() 
    {
        changeText = GetComponentInChildren<Text>();    
        moveUIAnimation = GetComponentInChildren<Animation>();
    }

    public IEnumerator AppearChangeUI()
    {
        yield return null;
        moveUIAnimation.Play();

        yield return new WaitWhile(() => moveUIAnimation.isPlaying);
        // StopCoroutine(AppearChangeUI());
    }

    public void CallAnimation(string stateString)
    {
        ChangeText(stateString);
        StartCoroutine(AppearChangeUI());
    }

    private void ChangeText(string stateString)
    {
        print(changeText);
        changeText.text = stateString;
    }
}
