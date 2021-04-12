using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SetBombtoCharacter", menuName = "ScriptableObjects/SetBombPosition/ToCharacter")]
public class SetBombtoCharacter : SetBombPositions
{
    //  public BattleController battleController;public BattleController battleController;

    // 폭탄에 대한 정보와 좌표 값을 가져와서 폭탄을 생성할 때 위치를 삼도록 하는 함수.
    // public override Vector3 SettoPos(Bomb _b, GameObject _target)
    // {
    //     return SetCharacter();
    // }

    // 폭탄을 설치할 때, 랜덤하게 결정하는 지, 특정한 규칙으로 결정되는 지 파악하는 함수.

    public Vector3 target;

    public void OnEnable()
    {
        target = Vector3.zero;
    }

    public override void DecideSetWay(CreateBomb _createBomb)
    {
        if (_createBomb.canSetBomb)
        {
            createBomb = _createBomb;

            SelectCharacter();
        }

        if (target != Vector3.zero)
        {
            
            CreateBomb.targetBomb.TransportBomb(BattleController.instance.GetNowPlayCharacter().transform.position, target);
        }
    }

    public void SelectCharacter()
    {
        SearchWithRayCast.SetLayer(layer);

        if (!SearchWithRayCast.GetHitSomething()) return;

        if (SearchWithRayCast.GetHitSomething().tag.Equals("Player") && Input.GetMouseButtonDown(0))
        {
            temp_Character = SearchWithRayCast.GetHitSomething().GetComponent<Temp_Character>();
            target = SearchWithRayCast.GetHitSomething().GetComponent<Temp_Character>().transform.position;

            CreateBomb.targetBomb.SetBombtoCharacter(temp_Character);
            CreateBomb.targetBomb.SetBombtoBombManager();
            // BombManager.AddBomb(CreateBomb.targetBomb);
            SearchWithRayCast.ReturnBasicLayer();
            createBomb.canSetBomb = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            createBomb.canSetBomb = false;
            BattleController.instance.SetCharacterAction(new WaitingOrder(BattleController.instance));
        }
    }
}
