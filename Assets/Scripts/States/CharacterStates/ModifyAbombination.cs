using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/ModifyAbombination")]
public class ModifyAbombination : CharacterAction, IBombCatch
{
    BattleUIManager battleUIManager;
    BombModifier bombModifier;
    CameraController cameraController;

    protected NowTurnCharacterManager nowTurnCharacterManager;

    ConeRangeMesh coneRangeMesh;

    protected BombData bomb;

    public ModifyAbombination(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        bombModifier = BombModifier.instance;
        bombModifier.modifyAbombination = this;
        
        characterActionController = CharacterActionController.instance;

        coneRangeMesh = nowTurnCharacterManager.GetNowCharacter().GetComponentInChildren<ConeRangeMesh>();

        battleUIManager = battleController.battleUIManager;
        cameraController = battleController.cameraController;
    }

    public override void EnterState()
    {
        ControllUI(battleUIManager);

        cameraController.ChangeCanChaseMousePos(false);

        if (bombModifier.modifiedCharacter)
            cameraController.SetZoomingCharacter(bombModifier.modifiedCharacter.transform);

        if (coneRangeMesh.visibleTargets.Count > 0)
        {
            bombModifier.SetModifiedCharacter(coneRangeMesh.visibleTargets[0].GetComponent<Temp_Character>());
        }
        else
        {
            bombModifier.SetModifiedCharacter(nowTurnCharacter);
        }
        Debug.Log("Enter 종료");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        bombModifier.ShowUI(true);

        //bombModifier.SetAbombinationModifier(this);

    }

    public override void UpdateState()
    {
        // if (bombModifier.modifiedCharacter)
        // {
        //     cameraController.MoveToCharacter();
        // }
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        bombModifier.ShowUI(false);
    }

    public void ChangeModifyAction(ModifyAbombination _ma)
    {
        characterActionController.SetState(_ma);
    }

    public void GetBomb(BombData _bomb)
    {
        bomb = _bomb;
    }
}
