using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Explosion", menuName = "ScriptableObjects/ExplosionMaking", order = 3)]
public class Explosion
{
    // 폭탄에 담길 폭발물을 의미하는 클래스.

    public string exploName;

    [TextArea]
    public string exploDescription;

    public Sprite exploImage;
    public GameObject exploEffect;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //폭.8물 가동!!!
    public void ExplosionActivate()
    {
        Debug.Log("폭발하고 말았다!");
    }

    public Explosion(bool _canStack, int _maxStack, int _countdown, int _minCountdown, int _maxCountdown)
    { //생성자

    }
}
