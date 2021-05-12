using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGuideLine : ScriptableObject
{
    public int bombID;
    public string bombName;

    [TextArea]
    public string bombDescription;

    public Sprite bombImage;
    // public GameObject bombObject;

    public Temp_Character bombOwner;
    public Temp_Character attachedTarget;

    public List<Explosion> explosionList = new List<Explosion>(30);

    // public List<Abombination> abombinationEffects = new List<Abombination>(10);

    public int bombCurCountDown; // 폭탄이 폭발물과 상관없이 작동하게 되는 카운트다운을 의미.
    public int bombMinCountDown;
    public int bombMaxCountDown;

    public int bombRadius;
    public bool bombCanStack;
    public int bombMaxStack;

    public int setUpCost;
    public int diffuseCost;
    public int boomCost;
    public int addCountdownCost;
    public int subtractCountdownCost;

    public ParticleSystem bombParticle;

    // public BombGuideLine(Temp_Character _temp_character)
    // {
    //     bombOwner = _temp_character;
    // }

    public virtual void Boom()
    {
        Debug.Log("폭탄이 폭발하였다!");
    }

    public virtual void Diffuse()
    {
        Debug.Log("폭탄이 해체되었다!");
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
        {
            explosionList.Remove(_e);
        }
    }

    public virtual void SetCountDown( int _min, int _max)
    {
        this.bombCurCountDown = Random.Range(_min, _max + 1);
    }

    public virtual void SetCountDown()
    {
        this.bombCurCountDown = Random.Range(this.bombMinCountDown, bombMaxCountDown + 1);
    }

    public void SetbombOwner(Temp_Character _tempCharacter)
    {
        bombOwner = _tempCharacter;
    }

    public void SetAttachedTarget(Temp_Character _target){
        attachedTarget = _target;
    }
}
