using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/MoveCharacter")]
public class MoveCharacter : CharacterAction
{
    public Vector3 from, to;

    public float alreadymoveDist;
    bool moving;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        // Setting ㄱㄱ
        from = BattleController.GetNowCharacterPos();
    }

    public override void ActCharacter()
    {
        Moving();
        // throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        CharacterBattleAction.nowAction = this;

        // _BattleUI.characterActUI.SetActive(false);
        _BattleUI.bombUI.SetActive(false);
        // 생성자로 지정되지 않을 것을 대비해 사용.
        if (!battleController)
            battleController = BattleController.instance;

        MoveOrder();
    }

    public void MoveOrder()
    {
        BattleController.cameraController.doZoom = false;
        from = BattleController.GetNowCharacterPos();
        to = Vector3.zero;
        alreadymoveDist = 0;
        SearchWithRayCast.ReturnBasicLayer();
    }

    public void Moving()
    {
        float canMoveDist = BattleController.nowPlayCharacter.info.characterMovement * 1f;

        if (Input.GetMouseButtonDown(1))
        {
            moving = true;
            to = new Vector3(SearchWithRayCast.GetHitPoint().x, BattleController.GetNowCharacterPos().y, SearchWithRayCast.GetHitPoint().z);

        }

        if (moving)
        {
            alreadymoveDist = Vector3.Distance(BattleController.GetNowCharacterPos(), from);

            if ((to != Vector3.zero && from != Vector3.zero)) // 이동 가능 거리가 남아있다면.
            {
                Vector3 temp_dist = Vector3.ClampMagnitude(to - from, BattleController.GetTemp_Character().info.characterMovement) + from;
                BattleController.SetNowCharacterPos(Vector3.MoveTowards(BattleController.GetNowCharacterPos(), temp_dist, 2f * Time.deltaTime));
            }
        }
    }
}