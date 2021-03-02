using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 폭발물의 뼈대를 생성. 이 후 상속을 통해 별도의 폭발물을 생성할 계획.
// [CreateAssetMenu(fileName = "New Explosion", menuName = "ScriptableObjects/ExplosionMaking", order = 3)]

// AccessAgree?: 보다 상위 행동을 진행하기 위해 
public enum ExplosionType { Attack, Defend, Buff, Debuff, Heal, AccessAgree }

public class Explosion : ScriptableObject
{
    // 폭탄에 담길 폭발물을 의미하는 클래스.

    public string exploName;

    [TextArea]
    public string exploDescription;

    public Sprite exploImage;
    // public GameObject exploEffect;

    public int exploDamage;
    public int exploRadius;
    public bool exploCanStack;
    public int exploMaxStack;
    public int[] exploDispelNum; // 폭발물을 해제하기 위해서 필요한 숫자들
    public int[] exploAugmentNum; // 폭발물을 강화하기 위해서 필요한 숫자들
    public int[] exploSetupNum; // 폭발물을 설치하기 위해서 필요한 숫자들

    public int exploCountDown; // 폭발물이 작동하는데 남은 시간

    public int exploMinCountDown;
    public int exploMaxCountDown;

    public int ExplosionRadius;

    //폭.8물 가동!!!
    public virtual void ExplosionActivate(Temp_Character _Character)
    {
        Debug.Log("폭발하고 말았다!");
    }
    // public virtual void ExplosionDiffuse(Temp_Character _Character)

    public virtual void ExplosionDiffuse()
    {
        Debug.Log("폭발하지 못했다...");
    }

    // public Explosion(bool _canStack, int _maxStack, int _countdown, int _minCountdown, int _maxCountdown)
    // { //생성자

    // }
}
