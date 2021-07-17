using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLoseState : BattleState
{
    // 적이 활동하게 될 페이즈: 적이 어떻게 활동할까?
    // 기본적으로 이동 -> 스킬, 폭탄 점착 등을 기본 베이스로 잡자.
    // 코스트를 확인한 뒤, 코스트에 캐릭터 조작을 진행한 뒤, 
    // 해당 캐릭터가 지닌 액션 포인트를 일부 조작하여 컨트롤한다는 형식으로.


    public BattleLoseState(BattleController _battleController) : base(_battleController)
    {
        base.battleController = _battleController;
        // SetEventBoxByString("BattleLose");
        // BattleStateEventBoxes.instance.CallByString("BattleLose");

    }

    public override IEnumerator EnterState()
    {
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        while (true)
        {
            yield return null;
        }
    }

    public override IEnumerator ExitState()
    {
        yield return null;
    }
}
