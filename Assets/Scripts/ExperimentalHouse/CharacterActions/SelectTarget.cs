using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : CharacterAction
{
    BattleUIManager battleUIManager;

    public SelectTarget(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = BattleController.instance;
        nowTurnCharacter = _battleController.GetNowPlayCharacter();

        battleUIManager = battleController.battleUIManager;
    }
    public override void EnterCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        // battleUIManager.
        // _BattleUI.ActivateActionUI(true);
    }

    public override void CharacterDataUpdate()
    {
        // throw new System.NotImplementedException();
        float hitPointX = SearchWithRayCast.GetHitPoint().x;
        float hitPointZ = SearchWithRayCast.GetHitPoint().z;
        float clampX = Mathf.Clamp(hitPointX, hitPointX - nowTurnCharacter.GetCharacterInfo().characterDetectRange, hitPointX + nowTurnCharacter.GetCharacterInfo().characterDetectRange);
        float clampZ = Mathf.Clamp(hitPointZ, hitPointZ - nowTurnCharacter.GetCharacterInfo().characterDetectRange, hitPointZ + nowTurnCharacter.GetCharacterInfo().characterDetectRange);

        Vector3 clampVector = new Vector3(clampX, 0, clampZ);

        // 지정 가능 범위 밖의 대상을 선택할 경우.
        if (Vector3.Distance(SearchWithRayCast.GetHitSomething().transform.position, battleController.GetNowCharacterPos()) > Vector3.Distance(clampVector, battleController.GetNowCharacterPos()))
        {
            Debug.Log("흠?");
        }
        else
        {
            Debug.Log("지정 범위 내 대상 발견");
        }
    }

    public override void CharacterPhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        throw new System.NotImplementedException();
    }
}