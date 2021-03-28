using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/DiffuseBomb")]
public class DiffuseBomb : CharacterAction
{
    List<Bomb> bombs;
    Bomb bomb;

    public DiffuseBomb(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
    }

    public override void ActCharacter()
    {
        if (bombs.Equals(bomb))
        {
            bomb.Diffuse();
            bombs.Remove(bomb);
            Debug.Log("폭탄 해제!");
        }
        Debug.Log("폭탄 해제?");
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        _BattleUI.OnOffUIManager(false);
        GetDiffuseBomb(_BattleUI.uitoShowBomb);
    }

    public void GetDiffuseBomb(UItoShowBombInfo _uitoShowBomb)
    {
        bombs = _uitoShowBomb.targetedCharacter.GetHaveBombs();
        bomb = _uitoShowBomb.targetedCharacter.GetHaveBombs()[_uitoShowBomb.indexBomb];
    }
}
