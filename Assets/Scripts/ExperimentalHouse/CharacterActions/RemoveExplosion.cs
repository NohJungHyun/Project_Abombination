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

    public override IEnumerator EnterState()
    {
        yield return null;
    }

    public override IEnumerator UpdateState()
    {
        yield return null;
    }

    public override IEnumerator PhysicUpdateState()
    {
        yield return null;
    }

    public override IEnumerator ExitState()
    {
        yield return null;
        // throw new System.NotImplementedException();
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