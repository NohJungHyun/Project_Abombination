using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/BoomBomb")]
public class BoomBomb : ModifyAbombination
{
    public BoomBomb(BattleController _battleController) : base(_battleController)
    {
        Debug.Log("BoomBomb에서 Init을 담당하고 있답니다");
        nowTurnCharacterManager = NowTurnCharacterManager.instance;
        characterActionController = CharacterActionController.instance;

        // Setting ㄱㄱ
        battleController = _battleController;
        nowTurnCharacter = nowTurnCharacterManager.GetNowCharacter();
    }

    public override void EnterState()
    {
        Debug.Log("BoomBomb에서 Enter를 담당하고 있답니다");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        Debug.Log("BoomBomb에서 UI를 담당하고 있답니다");
    }

    public override void UpdateState()
    {
        // 애니메이션같은 거 처리
        Debug.Log("BoomBomb에서 Update를 담당하고 있답니다");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // characterActionController.SetState(new ModifyAbombination(battleController));
            characterActionController.SetState(new WaitingOrder(battleController));
        }
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("BoomBomb에서 Exit를 담당하고 있답니다");
        bomb.Boom();
    }
}
