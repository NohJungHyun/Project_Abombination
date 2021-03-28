using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartSetPos { Hand, Point, Random, Character }

// [CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking", order = 2)]
public class Bomb : BombGuideLine
{
    //이 게임의 공격수단 장치이자, 주된 시스템을 차지하는 오브젝트.

    public int bombDamage;
    public GameObject boomObject;
    public int[] bombDispelNum; // 폭발물을 해제하기 위해서 필요한 숫자들
    public int[] bombAugmentNum; // 폭발물을 강화하기 위해서 필요한 숫자들
    public int[] bombSetupNum; // 폭발물을 설치하기 위해서 필요한 숫자들
    // public List<BombEffect> bombEffects = new List<BombEffect>();

    public Bomb(Temp_Character _temp_character) : base(_temp_character)
    {
        bombOwner = _temp_character;
    }

    public override void Boom()
    {
        Debug.Log("폭.발!");
    }

    // public List<AbombinationEffect> GetSetupEffects()
    // {
    //     return setupEffects;
    // }
    // public List<AbombinationEffect> GetAttachEffects()
    // {
    //     return attachEffects;
    // }
    // public List<AbombinationEffect> GetDiffuseEffects()
    // {
    //     return diffuseEffects;
    // }
    // public List<AbombinationEffect> GetBoomEffects()
    // {
    //     return boomEffects;
    // }
}
