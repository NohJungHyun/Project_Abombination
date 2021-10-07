using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterComponents
{
    [SerializeField]
    protected CharacterInfo info;
    protected Temp_Character owner;

    public abstract void Init();    

    public virtual void SetDataFromInfo(CharacterInfo info) => this.info = info;

    public CharacterComponents(CharacterInfo info)
    {
        SetDataFromInfo(info);
        Init();
    }

    public CharacterComponents(CharacterInfo info, Temp_Character _owner)
    {
        SetDataFromInfo(info);
        owner = _owner;
        Init();
    }

}
