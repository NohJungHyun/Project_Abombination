using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PlantBomb : CharacterAction
{
    IEnumerator coroutine;
    Temp_Character target;
    Bomb bomb;

    public AI_PlantBomb(BattleController b, Temp_Character target, Bomb setUpbomb) : base(b)
    {
        battleController = b;
        this.target = target;
        this.bomb = setUpbomb;
    }

    public override void EnterState()
    {
        Debug.Log("AI_PlantBomb Enter!");

        coroutine = SetBombToTarget(target, bomb);
        battleController.StartCoroutine(coroutine);
    }

    public override void UpdateState()
    {

    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        battleController.StopCoroutine(coroutine);
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public IEnumerator SetBombToTarget(Temp_Character character, Bomb bomb)
    {
        yield return null;

        character.GetHaveBombs().Add(bomb);
        bomb.attachedTarget = character;

        IEnumerator tempCoroutine = null;
        tempCoroutine = bomb.InvokeEventPlant();

        battleController.StartCoroutine(tempCoroutine);

        yield return null;

        battleController.StopCoroutine(tempCoroutine);

        Debug.LogFormat("{0}에게 {1}을 붙였다!", character.name, bomb);

        for(int i = 0; i < character.GetHaveBombs().Count; i++)
            Debug.Log(character.GetHaveBombs()[i]);
    }
}
