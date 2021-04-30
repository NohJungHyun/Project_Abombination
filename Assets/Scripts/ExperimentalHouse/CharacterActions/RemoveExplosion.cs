using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/RemoveExplosion")]
public class RemoveExplosion : ModifyAbombination
{
    public RemoveExplosion(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
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
    }

    public override void ExitCharacterAction()
    {
        // throw new System.NotImplementedException();
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