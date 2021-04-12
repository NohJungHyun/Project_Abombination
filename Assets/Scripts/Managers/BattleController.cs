using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// public enum BattlePhase { Nothing, BattleStart, RoundStart, CharacterTurnStart, CharacterTurn, CharacterTurnEnd, RoundEnd, BattleEnd }
public class BattleController : BattleStateMachine
{
    // 전투가 시작되면 전투를 파악하는 용도로 사용.
    // 전투 행동 순서, 사망여부 처리, 턴의 경과 등을 담당
    // 캐릭터 다수한테 전투관련 스크립트를 부착하는 것보다, 하나의 스크립트에서 처리하게 끔하여 최적화 추구

    // 외부 참조
    public static BattleController instance;

    public BattleUIManager battleUIManager;

    public CameraController cameraController;

    public Temp_Character target;

    public Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.
    public CharacterAction nowAction;

    public AreaIndicatorStorage areaIndicatorStorage;

    public List<Temp_Character> playerCharactersList = new List<Temp_Character>(10);
    public List<Temp_Character> enemyCharacterList = new List<Temp_Character>(10);

    public List<Temp_Character> characterList = new List<Temp_Character>(); // 전투에 참여하는 캐릭터들을 담는 리스트.

    public int battleRound = 0; // 배틀 경과 라운드
    public int battleTurn = 0; // 배틀 경과 턴

    public int index = 0; // 현재 선택된 캐릭터를 측정하기 위해 사용되는 카운터.

    public int canSetBombinBattle;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetState(new BattleStartState(this));
    }

    private void Update()
    {
        battleState.UpdateState(this);
    }

    public void NextTurn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeNowPlayerCharacter();
        }
    }

    public void ChangeNowPlayerCharacter()
    {
        battleTurn++;

        if (index == 0)
        {
            nowPlayCharacter = characterList[0];
            SetCharacterAction(new WaitingOrder(this));
            SetState(new PlayerTurnStartState(this));

        }
        else if (index < characterList.Count - 1)
        {
            //index++;
            nowPlayCharacter = characterList[index];
            Debug.Log("www");
            SetCharacterAction(new WaitingOrder(this));
            SetState(new PlayerTurnStartState(this));

        }
        else
        {
            index = 0;
            battleRound++;
            nowPlayCharacter = characterList[index];
            Debug.Log("eee");
            SetState(new RoundStartState(this));

        }

        // areaIndicatorStorage.MoveIndicator(areaIndicatorStorage.circleIndicator, nowPlayCharacter.transform);
        // areaIndicatorStorage.ModifyIndicatorSize(areaIndicatorStorage.circleIndicator, nowPlayCharacter.characterInfo.characterDetectRange);

        index++;
        // battleState.EnterState(this);
    }

    public override void SetState(BattleState _battleState)
    {
        battleState = _battleState;
        _battleState.EnterState(this);
        //throw new System.NotImplementedException();
    }

    public Vector3 GetNowCharacterPos()
    {
        return nowPlayCharacter.transform.position;
    }

    public Temp_Character GetNowPlayCharacter()
    {
        return nowPlayCharacter;
    }

    public void SetTemp_Character(Temp_Character _now)
    {
        nowPlayCharacter = _now;
    }
    public void SetCharacterAction(CharacterAction _CharacterAction)
    {
        CharacterAction ca = _CharacterAction;
        nowAction = ca;
        ca.ControllUI(battleUIManager);
    }

    public void SetMoveAction()
    {
        SetCharacterAction(new MoveCharacter(BattleController.instance));
    }

    public CharacterAction GetCharacterAction()
    {
        return nowAction;
    }

    void OnDrawGizmos()
    {
        if (SearchWithRayCast.hit.point != Vector3.zero)
        {
            if (Vector3.Distance(nowPlayCharacter.GetCharacterPos(), SearchWithRayCast.GetHitPoint()) < nowPlayCharacter.info.characterDetectRange)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(nowPlayCharacter.GetCharacterPos(), SearchWithRayCast.GetHitPoint());
            }
        }
    }

    public Temp_Character GetTargetedCharacter()
    {
        return target;
    }

    public void SetTargetedCharacter(Temp_Character _target)
    {
        target = _target;
    }

    public void SetBattleTurn(int _turnNum)
    {
        battleTurn = _turnNum;
    }
    public int GetBattleTurn()
    {
        return battleTurn;
    }
    public void SetBattleRound(int _roundNum)
    {
        battleRound = _roundNum;
    }

    public int GetBattleRound()
    {
        return battleRound;
    }
}
