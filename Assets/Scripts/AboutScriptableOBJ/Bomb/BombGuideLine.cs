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
    public SetBombPositions setBombPosition;

    public Temp_Character bombOwner;

    public List<Explosion> explosionList = new List<Explosion>(30);

    public List<AbombinationEffect> abombinationEffects = new List<AbombinationEffect>(10);

    public delegate void AbombinationTiming(Temp_Character _Character);
    public AbombinationTiming SetUpAbombination;
    public AbombinationTiming AttechedAbombination;
    public AbombinationTiming DiffuseAbombination;
    public AbombinationTiming BoomAbombination;

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

    // public BombGuideLine(Temp_Character _temp_character)
    // {
    //     bombOwner = _temp_character;
    // }

    public virtual void Boom()
    {
        foreach (Explosion exp in explosionList)
        {
            exp.ExplosionActivate(bombOwner);
        }
        explosionList.Clear();
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
        if (explosionList.Equals(_e))
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

    public void SetAbombination(AbombinationEffect _abomb)
    {
        abombinationEffects.Add(_abomb);

        for (int t = 0; t < _abomb.effectTiming.Count; t++)
        {
            switch (_abomb.effectTiming[t])
            {
                case EffectTiming.SetUp:
                    SetUpAbombination += _abomb.ActivateEffect;
                    break;
                case EffectTiming.Atteched:
                    AttechedAbombination += _abomb.ActivateEffect;
                    break;
                case EffectTiming.Diffuse:
                    DiffuseAbombination += _abomb.ActivateEffect;
                    break;
                case EffectTiming.Boom:
                    BoomAbombination += _abomb.ActivateEffect;
                    break;
            }
        }

    }
}
