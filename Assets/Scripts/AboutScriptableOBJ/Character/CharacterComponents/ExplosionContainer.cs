using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContainer : CharacterComponents
{
    public List<Explosion> canSetExplosions = new List<Explosion>();
    public List<Explosion> preparedExplosions = new List<Explosion>();

    public ExplosionContainer(CharacterInfo info, Temp_Character _owner) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        // Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        canSetExplosions.Clear();
        preparedExplosions.Clear();

        for (int e = 0; e < info.canSetExplosions.Count; e++)
            info.canSetExplosions[e] = ScriptableObject.Instantiate(info.canSetExplosions[e]);
        
    }

    public List<Explosion> GetCanSetExplosions()
    {
        return canSetExplosions;
    }
}
