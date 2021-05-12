using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking", order = 2)]
public class Bomb : BombGuideLine, ICanSetButtons, ICostable
{
    //이 게임의 공격수단 장치이자, 주된 시스템을 차지하는 오브젝트.

    // 폭탄에 일어날 수 있는 이벤트들을 델리게이트로 제작.
    public delegate void BombEventDelegate(Temp_Character _bombTarget);

    public event BombEventDelegate EventPlant;
    public event BombEventDelegate EventUpdate;
    public event BombEventDelegate EventBoom;
    public event BombEventDelegate EventDiffuse;

    // public delegate void BombEventInUpdate();
    // public BombEventInUpdate bombEventInUpdate;

    public void OnEnable()
    {
        EventBoom += TestMethod;
    }

    public override void Boom() //Temp_Character _target
    {
        EventBoom?.Invoke(attachedTarget);

        if (bombOwner.GetHaveBombs().Contains(this))// && BombManager.entireBombs.Contains(this))
        {
            explosionList.Clear();

            bombOwner.GetHaveBombs().Remove(this);
            // BombManager.RemoveBombFromEntire(this);
            Debug.Log("이렇게 폭탄 하나가 또 폭발하고 말았구나..");
        }
    }

    public void SetExplosionEvent()
    {
        for (int e = 0; e < GetExplosionsList().Count; e++)
        {

        }
    }

    public void SetToButton(Button _button)
    {

    }

    public void Use()
    {
    }

    public void AddToUse()
    {

    }

    public Sprite GetSprite()
    {
        return bombImage;
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

    public void TestMethod(Temp_Character _t){
        Debug.Log("안녕하세요?");
    }
}

