using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterBattleAction : MonoBehaviour
{
    // 캐릭터들의 행동을 별도로 관리하기 위해 만들어진 스크립트
    // 캐릭터들이 기본적으로 할 수 있는 행동(이동, 폭발물 설치, 폭탄 던지기 등)을 관리한다.
    // 캐릭터들이 지닌 고유의 활동들도 포함시킬 지는 미정
    // 여기서 처리한 결과를 return 해주는 것으로 결과값을 방출하자.
    // public static CharacterBattleAction instance;
    public BattleController battleController;

    public LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.

    [SerializeField]
    public List<CharacterAction> characterActions = new List<CharacterAction>(10); // 전투에서 캐릭터가 진행가능한 액션들을 담은 리스트.
    public static CharacterAction nowAction;

    public void Start()
    {
        battleController.battleUIManager.SetEventToActUI(this);
        nowAction = new TurnStart(battleController);
    }

    public void Update()
    {
        nowAction.ActCharacter();
    }

    public void CheckWhereBombs()
    {
        List<Temp_Character> detectedCharacters = new List<Temp_Character>();
        foreach (Collider col in Physics.OverlapSphere(battleController.nowPlayCharacter.transform.position, battleController.nowPlayCharacter.info.characterDetectRange, detectMask))
        {
            if (col.gameObject.GetComponent<Temp_Character>())
            {
                detectedCharacters.Add(col.gameObject.GetComponent<Temp_Character>());
            }
        }
        battleController.battleUIManager.GetCharacterPanel(detectedCharacters, battleController);
    }

    public void SetNowAction(CharacterAction _characterAction)
    {
        nowAction = _characterAction;
    }
}