using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingOrder : CharacterAction
{
    AreaIndicatorStorage areaIndicatorStorage;

    LayerMask characterLayer;

    public WaitingOrder(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        battleController = _battleController;
        areaIndicatorStorage = battleController.areaIndicatorStorage;

        characterLayer = LayerMask.GetMask("Characters");
    }

    public override void EnterCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public override void ActCharacterAction()
    {
        // throw new System.NotImplementedException();
        Debug.Log("WaitingOrder");

        // 간단하게 이동 명령 내리는 게 좋다고 생각이 들면 다시 한 번 시험해보도록 하자.
        // if (Input.GetMouseButtonDown(1) && !battleController.areaIndicatorStorage.GetCircleIndicator().activeInHierarchy)
        // {
        //     Debug.Log("sss");
        //     battleController.SetCharacterAction(new MoveCharacter(battleController));
        // }

        SearchWithRayCast.SetLayer(characterLayer);

        if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
        {
            float distToTarget = Vector3.Distance(nowTurnCharacter.transform.position, SearchWithRayCast.GetHitSomething().transform.position);

            if (distToTarget <= nowTurnCharacter.info.characterDetectRange)
            {
                Debug.Log("찾았다, 요 놈!");
            }
        }
    }

    public override void ExitCharacterAction()
    {
        SearchWithRayCast.ReturnBasicLayer();
    }

    public void EndCurTurn()
    {

    }
}
