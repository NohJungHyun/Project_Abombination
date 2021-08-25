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

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        
    }

    public override void PhysicUpdateState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

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