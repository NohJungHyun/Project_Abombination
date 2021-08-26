using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Move : CharacterAction
{
    Transform targetTransform;

    NavMeshAgent navMeshAgent;

    float canMoveDist;

    Bomb bomb;

    IEnumerator coroutine;

    public AI_Move(BattleController b, Transform t, Bomb bomb) : base(b)
    {
        battleController = b;
        targetTransform = t;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;

        this.bomb = bomb;

        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();
        canMoveDist = nowTurnCharacter.GetCharacterInfo().characterMovement;

        coroutine = MoveCharacter();
    }

    public override void EnterState()
    {
        battleController.StartCoroutine(coroutine);

        Debug.Log("AI_Move Enter");
    }

    public override void UpdateState()
    {
        // Move();
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        battleController.StopCoroutine(coroutine);
        Debug.Log("AI_Move Exit");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public IEnumerator MoveCharacter()
    {
        navMeshAgent.destination = targetTransform.position;

        while (true)
        {
            if (nowTurnCharacter.GetCharacterInfo().characterThrowRange > Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position))
            {
                navMeshAgent.isStopped = true;
                navMeshAgent.ResetPath();

                characterActionController.SetState(new AI_PlantBomb(battleController, targetTransform.GetComponent<Temp_Character>(), bomb));
            }
            yield return null;
        }
    }
}
