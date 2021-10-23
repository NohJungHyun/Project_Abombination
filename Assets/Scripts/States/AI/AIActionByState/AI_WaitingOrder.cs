using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_WaitingOrder : CharacterAction
{
    IEnumerator coroutine;
    CameraController cameraController;

    public void Init(Temp_Character a)
    {
        nowTurnCharacter = a;
    }
    // 일단 scriptableObject로 만들어보고, 정 안되겠다 싶으면 custom class 제작을 진행하자.

    public AI_WaitingOrder(BattleController b) : base(b)
    {
        nowTurnCharacter = NowTurnCharacterManager.nowPlayCharacter;
        characterActionController = CharacterActionController.instance;
        cameraController = battleController.cameraController;

        cameraController.SetZoomingCharacter(nowTurnCharacter.transform);
    }

    public IEnumerator SearchingTarget()
    {
        Debug.Log("기다려라");
        yield return null;

        // while (true)
        // {
        //     yield return null;


        // }

        if (!CheckCanSetBombsWithPoint())
        {
            yield return new WaitForSeconds(0.1f);
            battleController.SetState(new AI_CharacterTurnEnd(battleController));
        }
    }

    public override void EnterState()
    {
        Debug.Log("AI_WaitingOrder Enter!");

        coroutine = SearchingTarget();
        battleController.StartCoroutine(coroutine);
        // if(!CheckCanSetBombsWithPoint())
        //     battleController.SetState(new AI_CharacterTurnEnd(battleController));
    }

    public override void UpdateState()
    {
        Debug.Log("AI_WaitingOrder Update!");
        // cameraController.MoveToCharacter();
        // Debug.Log("AI_WaitingOrder Update!");
    }

    public override void PhysicUpdateState()
    {

    }

    public override void ExitState()
    {
        battleController.StopCoroutine(coroutine);
        Debug.Log("AI_WaitingOrder Exit!");
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        
    }

    public bool CheckCanSetBombsWithPoint()
    {
        if (nowTurnCharacter.CanSetBombsContainer.canSetBombs.Count > 0)
            for (int idx = 0; idx < nowTurnCharacter.CanSetBombsContainer.canSetBombs.Count; idx++)
                if (nowTurnCharacter.CanSetBombsContainer.canSetBombs[idx].setUpCost <= nowTurnCharacter.ActionPointController.GetActionPoint(0))
                {
                    Debug.Log("폭탄 설치를 진행하겠다");
                    SelectTarget(nowTurnCharacter.CanSetBombsContainer.canSetBombs[idx]);
                    return true;
                }
        
        return false;
    }

    public void SelectTarget(BombData b)
    {   
        if(b == null) return;

        Debug.Log("타켓 선택 입장");

        float nearDist = 1000;
        Transform nearest = null;

        Collider[] cols = Physics.OverlapSphere(b.GetOwner().gameObject.transform.position, b.GetOwner().GetCharacterInfo().characterDetectRange, b.layerMask);

        for (int c = 0; c < cols.Length; c++)
        {
            Debug.LogWarning(c);
            if (!cols[c].gameObject.activeSelf || cols[c].GetComponent<Temp_Character>() == NowTurnCharacterManager.nowPlayCharacter) continue;

            if (nearDist > Vector3.Distance(NowTurnCharacter.transform.position, cols[c].transform.position))
            {
                nearDist = Vector3.Distance(NowTurnCharacter.transform.position, cols[c].transform.position);
                nearest = cols[c].transform;
                 Debug.Log(nearest.name);
            }
        }

        if (nearest)
        {
            if (nearDist > NowTurnCharacter.CharacterMoveAreaController.curValue)
                characterActionController.SetState(new AI_Move(battleController, nearest, b));
            else
                characterActionController.SetState(new AI_PlantBomb(battleController, nearest.GetComponent<Temp_Character>(), b));
        }
    }
}
