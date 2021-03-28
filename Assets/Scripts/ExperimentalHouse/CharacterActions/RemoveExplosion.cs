using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/RemoveExplosion")]
public class RemoveExplosion : CharacterAction
{
    public RemoveExplosion(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }
    public override void ActCharacter()
    {
        throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    // 폭발물 해제
    public static void DoExplosionDiffuse(Explosion _e)
    {
        if (BattleController.nowPlayCharacter)
        {
            _e.ExplosionDiffuse(BattleController.nowPlayCharacter);
        }
        else
        {
            Debug.Log("지금은 캐릭터의 턴이 아니라 할 수 없습니다.");
        }
    }
}