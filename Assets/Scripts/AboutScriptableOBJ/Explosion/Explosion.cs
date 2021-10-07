using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 폭발물의 뼈대를 생성. 이 후 상속을 통해 별도의 폭발물을 생성할 계획.
// [CreateAssetMenu(fileName = "New Explosion", menuName = "ScriptableObjects/ExplosionMaking", order = 3)]

// AccessAgree?: 보다 상위 행동을 진행하기 위해 
public enum ExplosionType { Attack, Defend, Buff, Debuff, Heal, AccessAgree }

public class Explosion : NeedOwnerThings, ICanSetButtons, ICostable, IUsable
{
    public int exploRadius;
    public bool exploCanStack;
    public int exploMaxStack;
    // public int[] exploDispelNum; // 폭발물을 해제하기 위해서 필요한 숫자들
    // public int[] exploAugmentNum; // 폭발물을 강화하기 위해서 필요한 숫자들
    // public int[] exploSetupNum; // 폭발물을 설치하기 위해서 필요한 숫자들

    public int exploCountDown; // 폭발물이 작동하는데 남은 시간

    public int exploMinCountDown;
    public int exploMaxCountDown;

    public int needRemoveCost;
    public int needAddCost;

    // public List<Abombination> abombinations = new List<Abombination>();

    public delegate void ExplosionEventDelegate(Temp_Character _explosionTarget);
    public event ExplosionEventDelegate explosionPlantCarrier;
    public event ExplosionEventDelegate explosionUpdateCarrier;
    public event ExplosionEventDelegate explosionBoomCarrier;
    public event ExplosionEventDelegate explosionDiffuseCarrier;

    public virtual void OnEnable()
    {
        explosionPlantCarrier = null;
        explosionUpdateCarrier = null;
        explosionBoomCarrier = null;
        explosionDiffuseCarrier = null;
    }

    public void InvokeExplosionWithPlant(Temp_Character _explosionTarget)
    {
        explosionPlantCarrier?.Invoke(_explosionTarget);
    }
    public void InvokeExplosionWithUpdate(Temp_Character _explosionTarget)
    {
        explosionUpdateCarrier?.Invoke(_explosionTarget);
    }

    public void InvokeExplosionWithBoom(Temp_Character _explosionTarget)
    {
        Debug.Log("흐음...");
        explosionBoomCarrier?.Invoke(_explosionTarget);
    }
    public void InvokeExplosionWithDiffuse(Temp_Character _explosionTarget)
    {
        explosionDiffuseCarrier?.Invoke(_explosionTarget);
    }

    public void SetExplosionOwner(Temp_Character _owner)
    {
        owner = _owner;
    }

    public virtual void SetExplosionAllEvent(BombData _b)
    {
        // _b.EventPlant += InvokeExplosionWithPlant;
        // _b.EventUpdate += InvokeExplosionWithUpdate;
        // _b.EventBoom += InvokeExplosionWithBoom;
        // _b.EventDiffuse += InvokeExplosionWithDiffuse;      

        _b.EventPlant += InvokeExplosionWithPlant;
        _b.EventUpdate += InvokeExplosionWithUpdate;
        _b.EventBoom += InvokeExplosionWithBoom;
        _b.EventDiffuse += InvokeExplosionWithDiffuse;
    }

    public virtual void GetRidOfExplosionAllEvent(BombData _b)
    {
        _b.EventPlant -= InvokeExplosionWithPlant;
        _b.EventUpdate -= InvokeExplosionWithUpdate;
        _b.EventBoom -= InvokeExplosionWithBoom;
        _b.EventDiffuse -= InvokeExplosionWithDiffuse;
    }

    public void SetToButton(Button _button)
    {

    }

    public IEnumerator Use()
    {
        yield return null;
    }

    public ICanSetButtons GetCanSet()
    {
        return this;
    }

    public int PayCost(int _costNum)
    {
        return 0;
    }

    public bool CheckCost(int _costNum)
    {
        return false;
    }

    public IEnumerator PlayUseAnimation()
    {
        return null;
    }
}
