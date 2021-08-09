using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/MoveCharacter")]
public class MoveCharacter : CharacterAction
{
    public MoveCharacter instance;

    bool moving;
    ConeRangeMesh coneRangeMesh;
    Rigidbody rb;
    NavMeshAgent navMeshAgent;

    CameraController cameraController;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        nowTurnCharacter = _battleController.GetComponent<NowTurnCharacterManager>().GetNowCharacter();
        characterActionController = _battleController.GetComponent<CharacterActionController>();
        cameraController = _battleController.cameraController;

        coneRangeMesh = nowTurnCharacter.GetComponentInChildren<ConeRangeMesh>();
        rb = nowTurnCharacter.GetComponent<Rigidbody>();
        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();

        cameraController.SetZoomingCharacter(nowTurnCharacter.transform);
        // Setting ㄱㄱ        

        ControllUI(_battleController.battleUIManager);
        EnterState();
    }

    public override void EnterState()
    {
        coneRangeMesh.gameObject.SetActive(true);
        Debug.Log(this.GetType());
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.bombUI.SetActive(false);
    }

    public override void UpdateState()
    {
        cameraController.MoveToCharacter(nowTurnCharacter.transform);
    }

    public override void PhysicUpdateState()
    {
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            characterActionController.SetState(new WaitingOrder(battleController));
        }
        else
        {
            MovingWithNavMesh();
        }
    }

    public override void ExitState()
    {
        
    }

    public void Moving()
    {
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * nowTurnCharacter.GetCharacterInfo().characterMovement * Time.deltaTime;
        rb.MovePosition(nowTurnCharacter.GetCharacterPos() + movePos);
    }

    public void MovingWithNavMesh()
    {
        Debug.Log("Moving");
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * nowTurnCharacter.GetCharacterInfo().characterMovement ; //* Time.deltaTime
        navMeshAgent.destination = nowTurnCharacter.transform.position + movePos;
    }
}