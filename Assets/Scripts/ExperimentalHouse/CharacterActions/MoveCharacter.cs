using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/MoveCharacter")]
public class MoveCharacter : CharacterAction
{
    bool moving;
    ConeRangeMesh coneRangeMesh;
    Rigidbody rb;

    CameraController cameraController;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        nowTurnCharacter = _battleController.nowPlayCharacter;
        cameraController = _battleController.cameraController;

        coneRangeMesh = nowTurnCharacter.GetComponentInChildren<ConeRangeMesh>();
        rb = nowTurnCharacter.GetComponent<Rigidbody>();

        cameraController.SetZoomingCharacter(nowTurnCharacter.transform);
        // Setting ㄱㄱ        

        ControllUI(_battleController.battleUIManager);
        EnterCharacterAction();
    }

    public override void EnterCharacterAction()
    {
        coneRangeMesh.gameObject.SetActive(true);
        Debug.Log(this.GetType());
        //throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // _BattleUI.bombUI.SetActive(false);
    }

    public override void CharacterDataUpdate()
    {
        Moving();
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            battleController.SetCharacterAction(new WaitingOrder(battleController));
        }
    }

    public override void CharacterPhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {

    }

    public void Moving()
    {
        Debug.Log("Moving");
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * nowTurnCharacter.info.characterMovement * Time.deltaTime;
        rb.MovePosition(nowTurnCharacter.GetCharacterPos() + movePos);
    }
}