using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/MoveCharacter")]
public class MoveCharacter : CharacterAction
{
    ConeRangeMesh coneRangeMesh;
    NavMeshAgent navMeshAgent;

    CameraController cameraController;
    CharacterMovements characterMovements;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;
        
        coneRangeMesh = nowTurnCharacter.CharacterMoveAreaController.GetRangeMesh();

        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();
        characterMovements = nowTurnCharacter.GetComponent<CharacterMovements>();

        cameraController = _battleController.cameraController;
        cameraController.SetZoomingCharacter(nowTurnCharacter.transform);
        // Setting ㄱㄱ        

        ControllUI(_battleController.battleUIManager);
        EnterState();
    }

    public override void EnterState()
    {
        Debug.Log("MoveState EnterState!");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.bombUI.SetActive(false);
    }

    public override void UpdateState()
    {
        Debug.Log("MoveState UpdateState!");
        if(nowTurnCharacter.CharacterMoveAreaController.ShrinkArea(Time.deltaTime * nowTurnCharacter.GetCharacterInfo().moveAreaShrinkRate))
        {
            Debug.Log("영역 최소화 완료");
            // Vector3 fixedPos = nowTurnCharacter.transform.position;
            // nowTurnCharacter.CharacterMoveAreaController.HoldRangeMeshPos(fixedPos);
        }

        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            characterActionController.SetState(new WaitingOrder(battleController));    
     
    }

    public override void PhysicUpdateState()
    {
        characterMovements.Moving();  
    }

    public override void ExitState()
    {

    }
}