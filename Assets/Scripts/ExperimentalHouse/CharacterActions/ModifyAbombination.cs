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

    protected Bomb bomb;

    public ModifyAbombination(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacter = battleController.GetComponent<NowTurnCharacterManager>().GetNowCharacter();
        nowTurnCharacterManager = battleController.GetComponent<NowTurnCharacterManager>();
        characterActionController = battleController.GetComponent<CharacterActionController>();

        coneRangeMesh = nowTurnCharacterManager.coneRangeMesh;

        battleUIManager = battleController.battleUIManager;
        bombModifier = battleUIManager.bombModifier;
        cameraController = battleController.cameraController;
    }

    public override IEnumerator EnterState()
    {
        ControllUI(battleUIManager);

        cameraController.ChangeCanChaseMousePos(false);        

        if (coneRangeMesh.visibleTargets.Count > 0)
        {
            bombModifier.SetModifiedCharacter(coneRangeMesh.visibleTargets[0].GetComponent<Temp_Character>());
        }
        else
        {
            bombModifier.SetModifiedCharacter(nowTurnCharacter);
        }

        bombModifier.SetNowTurnPlayCharacter(nowTurnCharacter);

        yield return null;
        Debug.Log("Enter 종료");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        battleUIManager.TurnOnBombModifier(true);

        bombModifier.SetAbombinationModifier(this);
        
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {

            if (bombModifier.modifiedCharacter)
            {
                cameraController.MoveToCharacter(bombModifier.modifiedCharacter.transform);
            }
            
            yield return null;
        }
    }

    public override IEnumerator PhysicUpdateState()
    {
        //throw new System.NotImplementedException();
        yield return null;
    }


    public override IEnumerator ExitState()
    {
        battleUIManager.TurnOnBombModifier(false);
        yield return null;
    }

    public void ChangeModifyAction(ModifyAbombination _ma)
    {
        characterActionController.SetState(_ma);
    }

    public void GetBomb(Bomb _bomb)
    {
        bomb = _bomb;
    }
}
