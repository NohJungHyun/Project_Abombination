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

    public override IEnumerator EnterState()
    {
        coneRangeMesh.gameObject.SetActive(true);
        Debug.Log(this.GetType());
        //throw new System.NotImplementedException();
        yield return null;
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.bombUI.SetActive(false);
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            {
                characterActionController.SetState(new WaitingOrder(battleController));
            }
            else
            {
                MovingWithNavMesh();
            }
            

            yield return null;
        }
    }

    public override IEnumerator PhysicUpdateState()
    {
        yield return null;  
    }

    public override IEnumerator ExitState()
    {
         yield return null;
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