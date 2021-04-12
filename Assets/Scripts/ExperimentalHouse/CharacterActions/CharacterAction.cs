using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable]
public abstract class CharacterAction //: ScriptableObject
{
    protected static Temp_Character nowTurnCharacter;
    protected static BattleController battleController;
    public static Temp_Character NowTurnCharacter { get => nowTurnCharacter; }
    public static BattleController BattleController { get => battleController;}

    public abstract void ActCharacterAction();
    

    public abstract void EnterCharacterAction();
    public abstract void ExitCharacterAction();

    public abstract void ControllUI(BattleUIManager _BattleUI);

    public CharacterAction(BattleController _battleController)
    {
        nowTurnCharacter = _battleController.GetNowPlayCharacter();
        battleController = _battleController;
    }
}
