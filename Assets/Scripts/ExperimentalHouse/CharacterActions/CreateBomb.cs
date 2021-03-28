using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/CreateBomb")]
public class CreateBomb : CharacterAction
{
    public Temp_Character boomer;
    public bool canSetBomb = true;
    public static Bomb targetBomb;

    public static SetBombPositions bombPosition;

    public CreateBomb(BattleController _battleController) : base(_battleController)
    {

    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        _BattleUI.GetBombPanel();
    }
    public override void ActCharacter()
    {
        if(bombPosition)
            bombPosition.DecideSetWay(this);
    }

    public void CreateBombtoButtonClick(Bomb _bomb)
    {
        // 생성자로 지정되지 않을 것을 대비해 사용.
        if(!battleController)
            battleController = BattleController.instance;
        if(!temp_Character)
            boomer = BattleController.instance.GetTemp_Character();
        
        CharacterBattleAction.nowAction = this;
        canSetBomb = true;
        targetBomb = _bomb;

        bombPosition = _bomb.setBombPosition;
        bombPosition.createBomb = this;
    }
}
