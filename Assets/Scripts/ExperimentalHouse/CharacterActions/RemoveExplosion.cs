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

    public override void CharacterDataUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void CharacterPhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitCharacterAction()
    {
        // throw new System.NotImplementedException();
    }

    // 폭발물 해제
    public static void DoExplosionDiffuse(Bomb _bomb, Explosion _explosion)
    {
        if (_bomb.GetExplosionsList().Contains(_explosion))
        {
            _bomb.GetExplosionsList().Remove(_explosion);
        }
    }

}