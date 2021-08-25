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

    public IEnumerator<bool> MoveToTarget()
    {
        yield return false;
    }

    public IEnumerator MoveCharacter()
    {
        navMeshAgent.destination = targetTransform.position;

        while (true)
        {
            if (nowTurnCharacter.GetCharacterInfo().characterThrowRange > Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position))
            {
                // Debug.Log("현재 캐릭터의 위치: " + nowTurnCharacter.transform.position);
                // Debug.Log("타겟의 좌표: " + targetTransform.position);

                navMeshAgent.isStopped = true;
                navMeshAgent.ResetPath();

                characterActionController.SetState(new AI_PlantBomb(battleController, targetTransform.GetComponent<Temp_Character>(), bomb));
            }
            else
                Debug.Log("Distance:" + Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position));
            
            yield return null;
        }
    }

    // public void Move()
    // {
    //     // NowTurnCharacterManager.instance.nowPlayCharacter.SetCharacterPos(Vector3.MoveTowards(NowTurnCharacterManager.instance.nowPlayCharacter.gameObject.transform.position, targetTransform.position, speed * Time.deltaTime));
    //     if(1f > Vector3.Distance(nowTurnCharacter.transform.position, targetTransform.position))
    //         navMeshAgent.destination = targetTransform.position;
    //     else
    //         characterActionController.SetState(new AI_WaitingOrder(BattleController.instance));
    // }
}
