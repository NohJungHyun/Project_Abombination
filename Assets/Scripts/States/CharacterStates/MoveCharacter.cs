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

    Vector3 move;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;
        cameraController = _battleController.cameraController;

        coneRangeMesh = nowTurnCharacter.GetComponent<ConeRangeMesh>();
        navMeshAgent = nowTurnCharacter.GetComponent<NavMeshAgent>();
        characterMovements = nowTurnCharacter.GetComponent<CharacterMovements>();

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
        if (nowTurnCharacter.curMoveAreaRadius > nowTurnCharacter.GetCharacterInfo().minMoveAreaRadius)
        {
            nowTurnCharacter.curMoveAreaRadius -= Time.deltaTime * nowTurnCharacter.GetCharacterInfo().moveAreaShrinkRate;
            coneRangeMesh.SetRadius(nowTurnCharacter.curMoveAreaRadius);
        }

        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            characterActionController.SetState(new WaitingOrder(battleController));    

        // cameraController.SwitchCameraControlMethod(false);         
    }

    public override void PhysicUpdateState()
    {
        characterMovements.Moving();  
    }

    public override void ExitState()
    {

    }
}