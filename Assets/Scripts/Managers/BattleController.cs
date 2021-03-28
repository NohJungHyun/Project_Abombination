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

    public Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.

    public AreaIndicatorStorage areaIndicatorStorage;

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
        // characterList.Clear();
        // 모든 캐릭터들의 initiative를 계산한 후, characterList에 담는다.(전투 준비)
        battleUIManager.GetActCharacter();

        // foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(Temp_Character)))
        // {
        //     characterList.Add(obj.GetComponent<Temp_Character>());
        // }
        nowPlayCharacter = characterList[0];
        SetState(new BattleStartState(this));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // 다음 차례의 캐릭터 설정.
        {
            battleTurn++;

            if (index < characterList.Count - 1)
            {
                index++;
                nowPlayCharacter = characterList[index];
                SetState(new PlayerTurnStartState(this));
            }
            else
            {
                index = 0;
                battleRound++;
                nowPlayCharacter = characterList[index];
                SetState(new RoundStartState(this));
            }
            areaIndicatorStorage.MoveIndicator(areaIndicatorStorage.circleIndicator, nowPlayCharacter.transform);
               areaIndicatorStorage.ModifyIndicatorSize(areaIndicatorStorage.circleIndicator, nowPlayCharacter.characterInfo.characterDetectRange);
        }
        battleState.UpdateState(this);
    }

    public override void SetState(BattleState _battleState)
    {
        battleState = _battleState;
        _battleState.EnterState(this);
        //throw new System.NotImplementedException();
    }

    public void SetNowCharacterPos(Vector3 _vec)
    {
        nowPlayCharacter.transform.position = _vec;
    }

    public Vector3 GetNowCharacterPos()
    {
        return nowPlayCharacter.transform.position;
    }

    public Temp_Character GetTemp_Character()
    {
        return nowPlayCharacter;
    }

    public void SetTemp_Character(Temp_Character _now)
    {
        nowPlayCharacter = _now;
    }
}
