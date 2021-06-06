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

    public Participants nowTurnContoller;

    public BattleUIManager battleUIManager;

    public CameraController cameraController;

    public List<Participants> battleParticipants = new List<Participants>(10);

    public List<Temp_Character> playerCharactersList = new List<Temp_Character>(10);
    public List<Temp_Character> enemyCharacterList = new List<Temp_Character>(10);

    public List<Temp_Character> characterList = new List<Temp_Character>(); // 전투에 참여하는 캐릭터들을 담는 리스트.

    public Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.

    public List<Transform> targetedCharacters;

    public CharacterAction nowAction;

    public ConeRangeMesh coneRangeMesh;

    public int battleRound = 0; // 배틀 경과 라운드
    public int battleTurn = 0; // 배틀 경과 턴

    public int index = 0; // 현재 선택된 캐릭터를 측정하기 위해 사용되는 카운터.

    public Vector3 baseCharacterPos;

    // public delegate void ReactionDelegate();

    // public static ReactionDelegate reactionDele;


    void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        nowTurnContoller = battleParticipants[0];
        SetState(new BattleStartState(this));

    }

    private void Update()
    {
        battleState.UpdateState();

        if (nowAction != null)
            nowAction.CharacterDataUpdate();
    }

    private void FixedUpdate()
    {
        if (nowAction != null)
            nowAction.CharacterPhysicUpdate();
    }

    public override void SetState(BattleState _battleState)
    {
        if (battleState != null)
            battleState.ExitState();

        battleState = _battleState;

        if (battleState != null)
            battleState.EnterState();

    }

    public Vector3 GetNowCharacterPos()
    {
        return nowPlayCharacter.transform.position;
    }

    public Temp_Character GetNowPlayCharacter()
    {
        return nowPlayCharacter;
    }

    public void SetNowCharacter(Temp_Character _now)
    {
        nowPlayCharacter = _now;
        // coneRangeMesh.transform.position = Vector3.zero;
    }

    public void SetCharacterAction(CharacterAction _CharacterAction)
    {
        if (nowAction != null)
            nowAction.ExitCharacterAction();

        nowAction = _CharacterAction;

        if (nowAction != null)
            nowAction.EnterCharacterAction();
    }

    public CharacterAction GetCharacterAction()
    {
        return nowAction;
    }

    public List<Transform> GetTargetedCharacter()
    {
        return targetedCharacters;
    }

    public void AddTargetedCharacter(Transform _target)
    {
        targetedCharacters.Add(_target);
    }

    public void RemoveTargetedCharacter(Transform _target)
    {
        if (targetedCharacters.Equals(_target))
            targetedCharacters.Remove(_target);
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

    public void TransportTargetsToList()
    {
        targetedCharacters = coneRangeMesh.visibleTargets;
    }
}
