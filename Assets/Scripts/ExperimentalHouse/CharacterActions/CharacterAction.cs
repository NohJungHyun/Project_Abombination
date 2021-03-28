using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CharacterAction //: ScriptableObject
{
    public static CharacterAction instance;
    protected static Temp_Character temp_Character;
    protected static BattleController battleController;
    public static Temp_Character Temp_Character { get => temp_Character; }
    public static BattleController BattleController { get => battleController;}

    public abstract void ActCharacter();
    public abstract void ControllUI(BattleUIManager _BattleUI);

    public CharacterAction(BattleController _battleController)
    {
        temp_Character = _battleController.GetTemp_Character();
        battleController = _battleController;
    }

    public virtual void onEnable()
    {
        instance = this;
    }
}
