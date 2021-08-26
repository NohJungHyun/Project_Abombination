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

        target.GetHaveBombs().Add(bomb);
        bomb.attachedTarget = target;

        nowTurnCharacter.actionPoint -= bomb.setUpCost;

        IEnumerator tempCoroutine = bomb.Use();
        battleController.StartCoroutine(tempCoroutine);

        yield return null;   

        characterActionController.SetState(new AI_WaitingOrder(battleController));
    }
}
