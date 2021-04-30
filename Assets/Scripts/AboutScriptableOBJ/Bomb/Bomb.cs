using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartSetPos { Hand, Point, Random, Character }

// [CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking", order = 2)]
public class Bomb : BombGuideLine
{
    //이 게임의 공격수단 장치이자, 주된 시스템을 차지하는 오브젝트.

    public int bombDamage;
    public GameObject bombObject; // 폭탄이 구현될 때 생성할 게임 오브젝트.
    public int[] bombDispelNum; // 폭발물을 해제하기 위해서 필요한 숫자들
    public int[] bombAugmentNum; // 폭발물을 강화하기 위해서 필요한 숫자들
    public int[] bombSetupNum; // 폭발물을 설치하기 위해서 필요한 숫자들

    public GameObject instantiatedBomb;

    public GameObject bombTrail;
    public bool isGoal;
    // public List<BombEffect> bombEffects = new List<BombEffect>();

    // public Bomb(Temp_Character _temp_character) : base(_temp_character)
    // {
    //     bombOwner = _temp_character;
    // }

    public override void Boom()
    {
        if (!bombOwner)
            bombOwner = BattleController.instance.GetNowPlayCharacter();

        if (bombOwner.GetHaveBombs().Equals(this))
        {
            bombOwner.GetHaveBombs().Remove(this);
        }
        Debug.Log("이렇게 폭탄 하나가 또 폭발하고 말았구나..");
    }
    
    public void SetBombtoBombManager()
    {
        BombManager.AddBomb(this);
    }

    // public void TransportBomb(Vector3 _from, Vector3 _to)
    // {
    //     if (!instantiatedBomb)
    //     {
    //         instantiatedBomb = Instantiate(bombObject, _from, Quaternion.identity);
    //     }

    //     if (Vector3.Distance(instantiatedBomb.transform.position, _to) <= 0.25f || isGoal)
    //     {
    //         instantiatedBomb.SetActive(false);
    //         isGoal = true;
    //         instantiatedBomb.transform.position = _from;            
    //     }
    //     else
    //     {
    //         instantiatedBomb.SetActive(true);
    //         instantiatedBomb.transform.position = Vector3.MoveTowards(instantiatedBomb.transform.position, _to, 5f * Time.deltaTime); 
    //     }
    // }

    // public GameObject GetbombObject()
    // {
    //     return bombObject;
    // }

    // public void SetBombtoCharacter(Temp_Character _target)
    // {
    //     SetCountDown(bombMinCountDown, bombMaxCountDown);
    //     _target.haveBombs.Add(this);
    // }

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
