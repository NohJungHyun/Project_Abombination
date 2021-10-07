using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PlantBomb : CharacterAction
{
    IEnumerator coroutine;
    Temp_Character target;
    BombData bomb;

    public AI_PlantBomb(BattleController b, Temp_Character target, BombData setUpbomb) : base(b)
    {
        characterActionController = CharacterActionController.instance;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        battleController = b;

        this.target = target;
        this.bomb = setUpbomb;
        
        coroutine = SetBombToTarget();
    }

    public override void EnterState()
    {
        Debug.Log("AI_PlantBomb Enter!");

        battleController.StartCoroutine(coroutine);
             
    }

    public override void UpdateState()
    {
        Debug.Log("AI_PlantBomb Update!");
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("AI_PlantBomb Exit!");
        battleController.StopCoroutine(coroutine);
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public IEnumerator SetBombToTarget()
    {
        yield return null;

        target.CarriedBombContainer.GetHaveBombs().Add(bomb);
        bomb.attachedTarget = target;

        nowTurnCharacter.ActionPointController.SubtractActionPoint(0, bomb.setUpCost, 0);

        Debug.Log(nowTurnCharacter.name + ": " + nowTurnCharacter.ActionPointController.GetActionPoint(0));

        IEnumerator tempCoroutine = bomb.Use();
        battleController.StartCoroutine(tempCoroutine);

        yield return null;

        characterActionController.SetState(new AI_WaitingOrder(battleController));
    }
}
