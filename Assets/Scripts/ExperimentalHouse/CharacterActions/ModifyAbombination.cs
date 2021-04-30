using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/ModifyAbombination")]
public class ModifyAbombination : CharacterAction
{
    BattleUIManager battleUIManager;
    BombModifier bombModifier;
    CameraController cameraController;

    int characterIndex = 0;

    protected Bomb bomb;
    
    public ModifyAbombination(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacter = _battleController.GetNowPlayCharacter();
        cameraController = battleController.cameraController;

        battleUIManager = battleController.battleUIManager;
        bombModifier = battleUIManager.bombModifier;   
    
    }

    public override void EnterCharacterAction()
    {  
        Debug.Log("characterIndex: " + characterIndex);
        ControllUI(battleUIManager);

        // targetedCharacters = coneRangeMesh.GetVisibleTargets();
        cameraController.ChangeCanChaseMousePos(false);


        battleController.TransportTargetsToList();
        bombModifier.SetNowTurnPlayCharacter(nowTurnCharacter);
        bombModifier.SetModifiedCharacter(battleController.GetTargetedCharacter()[characterIndex].GetComponent<Temp_Character>());
    }


    public override void ControllUI(BattleUIManager _BattleUI)
    {
        bombModifier.gameObject.SetActive(true);
    }

    public override void ActCharacterAction()
    {
        cameraController.MoveToCharacter(battleController.GetTargetedCharacter()[characterIndex]);

        if (battleController.targetedCharacters.Count > 0)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A: " + characterIndex);
                if(characterIndex < 1) return;

                characterIndex--;
                Debug.Log("characterIndex--: " + characterIndex);
                
                bombModifier.SetModifiedCharacter(battleController.targetedCharacters[characterIndex].GetComponent<Temp_Character>());
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D: " + characterIndex);
                if(characterIndex > battleController.targetedCharacters.Count) return;

                characterIndex++;
                Debug.Log("characterIndex++: " + characterIndex);

                bombModifier.SetModifiedCharacter(battleController.targetedCharacters[characterIndex].GetComponent<Temp_Character>());
                
            }

            if(battleController.targetedCharacters.Equals(SearchWithRayCast.GetHitCharacter()))
            {
                Debug.Log("하히후헤호");
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bombModifier.EscapeModify();
            battleController.SetCharacterAction(new WaitingOrder(battleController));
        }
    }

    public override void ExitCharacterAction()
    {
        // scrollRect.gameObject.SetActive(false);
        // throw new System.NotImplementedException();
    }

    public virtual void GetBomb(Bomb _b)
    {
        bomb = _b;
    }
}
