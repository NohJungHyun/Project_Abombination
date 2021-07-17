using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CharacterAction : IState
{
    protected Temp_Character nowTurnCharacter;
    protected BattleController battleController;
    public Temp_Character NowTurnCharacter { get => nowTurnCharacter; }
    public BattleController BattleController { get => battleController; }

    public CharacterActionController characterActionController;

    public abstract IEnumerator EnterState();
    public abstract IEnumerator UpdateState();
    public abstract IEnumerator PhysicUpdateState();
    public abstract IEnumerator ExitState();

    public abstract void ControllUI(BattleUIManager _BattleUI);

    public CharacterAction(BattleController _battleController)
    {
        battleController = _battleController;
    }
}
