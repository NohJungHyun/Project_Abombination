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
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;
    }

    public override void EnterState()
    {
        Debug.Log("AI_WaitingOrder Enter!");

        // SelectTarget(CheckCanSetBombsWithPoint());
        if(!CheckCanSetBombsWithPoint())
            battleController.SetState(new AI_CharacterTurnEnd(battleController));
        // battleController.SetState(new AI_SelectCharacter(battleController));
    }

    public override void UpdateState()
    {
        Debug.Log("AI_WaitingOrder Update!");
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        Debug.Log("AI_WaitingOrder Exit!");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {

    }

    public bool CheckCanSetBombsWithPoint()
    {
        if (nowTurnCharacter.GetCharacterInfo().canSetBombs.Count > 0)
        {
            for (int idx = 0; idx < nowTurnCharacter.GetCharacterInfo().canSetBombs.Count; idx++)
            {
                if (nowTurnCharacter.GetCharacterInfo().canSetBombs[idx].setUpCost < nowTurnCharacter.actionPoint)
                {
                    Debug.Log("폭탄 설치를 진행하겠다");
                    SelectTarget(nowTurnCharacter.GetCharacterInfo().canSetBombs[idx]);
                    return true;
                }
            }
        }
        return false;
    }

    public void SelectTarget(Bomb b)
    {   
        if(b == null) return;

        float nearDist = 1000;
        Transform nearest = null;

        Collider[] cols = Physics.OverlapSphere(b.GetOwner().gameObject.transform.position, b.GetOwner().GetCharacterInfo().characterDetectRange, b.layerMask);

        for (int c = 0; c < cols.Length; c++)
        {
            Debug.Log(cols[c].name);

            if(cols[c].GetComponent<Temp_Character>() == NowTurnCharacterManager.nowPlayCharacter)
                continue;

            if (nearDist > Vector3.Distance(b.GetOwner().gameObject.transform.position, cols[c].transform.position))
            {
                nearDist = Vector3.Distance(b.GetOwner().gameObject.transform.position, cols[c].transform.position);
                nearest = cols[c].transform;
            }
        }

        if (nearDist > b.GetOwner().GetCharacterInfo().characterMovement && nearest)
            characterActionController.SetState(new AI_Move(battleController, nearest, b));
        else
            characterActionController.SetState(new AI_PlantBomb(battleController, nearest.GetComponent<Temp_Character>(), b));
    }
}
