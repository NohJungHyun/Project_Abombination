using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Move : CharacterAction
{
    CameraController cameraController;

    Transform targetTransform;

    NavMeshAgent navMeshAgent;

    float canMoveDist;

    BombData bomb;

    IEnumerator coroutine;

    public AI_Move(BattleController b, Transform t, BombData bomb) : base(b)
    {
        battleController = b;
        targetTransform = t;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;
        cameraController = battleController.cameraController;

        this.bomb = bomb;

        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();
        canMoveDist = nowTurnCharacter.GetCharacterInfo().characterMovement;
        cameraController.SetZoomingCharacter(nowTurnCharacter.transform);

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
        // cameraController.MoveToCharacter();
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
            yield return new WaitUntil(() => nowTurnCharacter.GetCharacterInfo().characterThrowRange > Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position));

            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();

            characterActionController.SetState(new AI_PlantBomb(battleController, targetTransform.GetComponent<Temp_Character>(), bomb));
            yield return null;
        }
    }
}
