using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking", order = 2)]
public class BombData : NeedOwnerThings, ICostable, IUsable
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

    [SerializeField]
    protected int bombCurCountDown; // 폭탄이 폭발물과 상관없이 작동하게 되는 카운트다운을 의미.
    [SerializeField]
    protected int bombMinCountDown;
    [SerializeField]
    protected int bombMaxCountDown;

    protected float bombRadius;
    protected bool bombCanStack;
    protected int bombMaxStack;

    public int setUpCost;
    public int diffuseCost;
    public int boomCost;
    public int addCountdownCost;
    public int subtractCountdownCost;

    public int CurCountDown
    {
        get { return bombCurCountDown; }
        set { bombCurCountDown = value; }
    }

    public ParticleSystem boomEffect;

    public List<OccurrenceTemplate> occurrences = new List<OccurrenceTemplate>();

    public IEnumerator Use()
    {
        EventPlant?.Invoke(attachedTarget);
        SendBox();
        yield return null;
    }

    public virtual void Boom() //Temp_Character _target
    {
        Debug.Log("이렇게 폭탄 하나가 또 폭발하고 말았구나..");
        // EventBoom?.Invoke(attachedTarget);
        
        owner.StartCoroutine(PlayUseAnimation());
        RemoveBomb();
        
        // owner.StopCoroutine(coroutine);
    }

    public virtual void Diffuse()
    {
        Debug.Log("폭탄이 해체되었다!");
        EventDiffuse?.Invoke(attachedTarget);
        // RemoveBomb();
    }

    public void SendBox()
    {
        for(int i = 0; i < occurrences.Count; i++)
        {
            occurrences[i].SpreadtoBattleContainer(owner);
            Debug.Log(occurrences[i].name);
        }
            
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

    public void SetBombOwner(Temp_Character _tempCharacter)
    {
        owner = _tempCharacter;
    }

    public void SetAttachedTarget(Temp_Character _target)
    {
        attachedTarget = _target;
    }

    public void RemoveBomb()
    {
        if (owner.CarriedBombContainer.GetHaveBombs().Contains(this))
        {
            this.explosionList.Clear();
            owner.CarriedBombContainer.GetHaveBombs().Remove(this);
            Destroy(this);
        }

        Debug.Log("남은 폭탄 수: " + owner.CarriedBombContainer.GetHaveBombs().Count);
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

    public void AdjustCurCountDown(int num)
    {
        bombCurCountDown += num;

        if(CurCountDown <= 0)
        {
            Boom();
        }
    }

    public IEnumerator PlayUseAnimation()
    {
        if(boomEffect == null) yield break;

        yield return null;

        ParticleSystem particle = Instantiate(boomEffect, attachedTarget.transform.position, Quaternion.identity);

        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        var main = particle.main;
        main.useUnscaledTime = true;

        while (particle.isPlaying)
        {
            yield return null;
            Debug.Log("엥");
        }

        main.useUnscaledTime = false;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

        Destroy(particle.gameObject);
        Debug.Log("사라졌니?: " + particle);

        owner.StopCoroutine(PlayUseAnimation());

        // Time.timeScale = 0.1f;
        //Debug.Log("particle " + particle.main.duration);

        // Time.timeScale = 1f;

    }
}

