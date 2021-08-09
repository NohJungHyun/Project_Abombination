using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_WaitingOrder : CharacterAction
{
    public void Init(Temp_Character a)
    {
        nowTurnCharacter = a;
    }
    // 일단 scriptableObject로 만들어보고, 정 안되겠다 싶으면 custom class 제작을 진행하자.

    public AI_WaitingOrder(BattleController b) : base(b)
    {

    }

    public override void EnterState()
    {
        if (nowTurnCharacter.GetCharacterInfo().canSetBombs.Count > 0)
        {
            foreach (Bomb b in nowTurnCharacter.GetCharacterInfo().canSetBombs)
            {
                if (b.setUpCost < nowTurnCharacter.actionPoint)
                {
                    Debug.Log("폭탄 설치를 진행하겠다");
                    SelectTarget(b);
                    break;
                }
            }
        }
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

    public void SelectTarget(Bomb b)
    {
        float nearDist = 1000;
        Transform nearest = null;

        Collider[] cols = Physics.OverlapSphere(b.GetOwner().gameObject.transform.position, b.GetOwner().GetCharacterInfo().characterDetectRange, b.layerMask);

        for (int c = 0; c < cols.Length; c++)
        {
            if (nearDist > Vector3.Distance(b.GetOwner().gameObject.transform.position, cols[c].transform.position))
            {
                nearDist = Vector3.Distance(b.GetOwner().gameObject.transform.position, cols[c].transform.position);
                nearest = cols[c].transform;
            }
        }

        if (nearDist > b.GetOwner().GetCharacterInfo().characterMovement)
            battleController.SetState(new AI_Move(battleController, nearest));
        // else
        //폭탄 설치
    }
}
