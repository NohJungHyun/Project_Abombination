using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAction
{
    void CharacterDataUpdate();
    
    void CharacterPhysicUpdate();

    void EnterCharacterAction();
    void ExitCharacterAction();

    void ControllUI(BattleUIManager _BattleUI);
}
