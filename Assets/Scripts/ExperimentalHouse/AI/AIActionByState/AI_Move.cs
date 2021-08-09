using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Move : CharacterAction
{
    Transform targetTransform;
    public float speed;

    NavMeshAgent navMeshAgent;

    float canMoveDist;

    public AI_Move(BattleController b, Transform t) : base(b)
    {
        battleController = b;
        targetTransform = t;

        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();

        canMoveDist = nowTurnCharacter.GetCharacterInfo().characterMovement;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        Move();
    }

    public override void PhysicUpdateState()
    {
        
    }

    public override void ExitState()
    {

    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public void Move()
    {
        // NowTurnCharacterManager.instance.nowPlayCharacter.SetCharacterPos(Vector3.MoveTowards(NowTurnCharacterManager.instance.nowPlayCharacter.gameObject.transform.position, targetTransform.position, speed * Time.deltaTime));
        if(1f > Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position))
            navMeshAgent.destination = targetTransform.position;
        else
            characterActionController.SetState(new AI_WaitingOrder(BattleController.instance));
    }
}
