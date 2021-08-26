using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking", order = 2)]
public class Bomb : NeedOwnerThings, ICostable, IUsable
{
    //이 게임의 공격수단 장치이자, 주된 시스템을 차지하는 오브젝트.

    // 폭탄에 일어날 수 있는 이벤트들을 델리게이트로 제작.
    public delegate void BombEventDelegate(Temp_Character _bombTarget);

    public event BombEventDelegate EventPlant;
    public event BombEventDelegate EventUpdate;
    public event BombEventDelegate EventBoom;
    public event BombEventDelegate EventDiffuse;

    public Temp_Character attachedTarget;
    public LayerMask layerMask;

    public List<Explosion> explosionList = new List<Explosion>(30);

    // public List<Abombination> abombinationEffects = new List<Abombination>(10);

    public int bombCurCountDown; // 폭탄이 폭발물과 상관없이 작동하게 되는 카운트다운을 의미.
    public int bombMinCountDown;
    public int bombMaxCountDown;

    public float bombRadius;
    public bool bombCanStack;
    public int bombMaxStack;

    public int setUpCost;
    public int diffuseCost;
    public int boomCost;
    public int addCountdownCost;
    public int subtractCountdownCost;

    public GameObject boomEffect22;

    public IEnumerator Use()
    {
        EventPlant?.Invoke(attachedTarget);
        yield return null;
    }

    public void SetToButton(Button _button)
    {

    }

    public virtual void Boom() //Temp_Character _target
    {
        Debug.Log("이렇게 폭탄 하나가 또 폭발하고 말았구나..");
        EventBoom?.Invoke(attachedTarget);
        RemoveBomb();
    }

    public virtual void Diffuse()
    {
        Debug.Log("폭탄이 해체되었다!");
        EventDiffuse?.Invoke(attachedTarget);
        RemoveBomb();
    }

    public List<Explosion> GetExplosionsList()
    {
        return explosionList;
    }

    public void SetExplosionList(List<Explosion> _explosionList)
    {
        explosionList = _explosionList;
    }

    public void AddExplosionToList(Explosion _e, int _i)
    {
        explosionList.Insert(_i, _e);
    }

    public void RemoveExplosionToList(Explosion _e)
    {
        if (explosionList.Contains(_e))
            explosionList.Remove(_e);
        
    }

    public virtual void SetCountDown(int _min, int _max)
    {
        this.bombCurCountDown = Random.Range(_min, _max + 1);
    }

    public virtual void SetCountDown()
    {
        this.bombCurCountDown = Random.Range(this.bombMinCountDown, bombMaxCountDown + 1);
    }

    public void SetbombOwner(Temp_Character _tempCharacter)
    {
        owner = _tempCharacter;
    }

    public void SetAttachedTarget(Temp_Character _target)
    {
        attachedTarget = _target;
    }


    public int PayCost(int _costNum)
    {
        return 0;
    }

    public bool CheckCost(int _costNum)
    {
        return false;
    }

    public void SetExplosionEvent()
    {
        for (int e = 0; e < GetExplosionsList().Count; e++)
        {

        }
    }

    public void RemoveBomb()
    {
        if (owner.GetHaveBombs().Contains(this))// && BombManager.entireBombs.Contains(this))
        {
            explosionList.Clear();
            owner.GetHaveBombs().Remove(this);
        }
    }

    public IEnumerator PlayUseAnimation()
    {
        if (boomEffect22.GetComponent<ParticleSystem>())
        {
            boomEffect22.GetComponent<ParticleSystem>().Play();
        }
        yield return null;
    }
}

