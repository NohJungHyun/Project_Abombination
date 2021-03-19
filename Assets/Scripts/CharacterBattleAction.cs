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
    public static CharacterBattleAction instance;

    public BattleController battleController;

    // public BombManager bombManager;

    // public Temp_Character action_Character;

    public LayerMask detectMask; // 폭탄, 캐릭터를 분간한 뒤 게임 오브젝트를 선택적으로 찾아내기 위해 사용.

    public Vector3 from, to; // 캐릭터가 이동하기 전에, 자신의 위치를 담은 변수. 
    public float alreadymoveDist;

    // public bool alreadyMove;

    public bool movePhase, setUpPhase;
    bool moving;

    public void Start()
    {
        instance = this;
    }

    public void Update()
    {
        if (movePhase)
        {
            setUpPhase = false;
            Moving();
        }
        else if (setUpPhase)
        {
            movePhase = false;
        }
    }

    public void MoveOrder()
    {
        battleController.doZoom = false;
        movePhase = true;
        from = battleController.GetNowCharacterPos();
    }

    public void Moving()
    {     
        float canMoveDist = battleController.nowPlayCharacter.characterInfo.characterMovement * 1f;

        if (alreadymoveDist > canMoveDist){
            print("B");
            to = Vector3.zero;
            from = Vector3.zero;
            movePhase = false;
            moving = false;
            alreadymoveDist = 0;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            moving = true;
            battleController.SearchwithRayCast();

            to = new Vector3(battleController.GetHitPoint().x, battleController.GetNowCharacterPos().y, battleController.GetHitPoint().z);
        }
        
        if(moving){
            if (to != Vector3.zero || from != Vector3.zero)
            {
                alreadymoveDist = Vector3.Distance(battleController.GetNowCharacterPos(), from);
                Vector3 movedPos = Vector3.MoveTowards(battleController.GetNowCharacterPos(), to, 3f * Time.deltaTime);
                battleController.SetNowCharacterPos(movedPos);
            }
        }
    }

    public void CreateBomb()
    {
        setUpPhase = true;
        battleController.battleUIManager.GetBombPanel(battleController.nowPlayCharacter.GetCanSetBombs(), battleController);
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

    public void DiffuseBomb(List<Bomb> _bombs, Bomb _bomb)
    {
        if (_bombs.Count > 0)
        {
            _bomb.Diffuse();
            _bombs.Remove(_bomb);
        }
    }

    // 폭발물 설치
    public void DoExplosionSetUp(Explosion _e, UItoShowBombInfo _ui)
    {
        print(battleController.nowPlayCharacter.name);

        if (_ui.targetedCharacter && _ui.targetedCharacter.GetHaveBombs()[_ui.indexBomb])
        {
            Explosion cloneExplosion = _e;
            _ui.targetedCharacter.GetHaveBombs()[_ui.indexBomb].AddExplosionToList(_e, 0);
            //_ui.ExhibitExplosionsCondition(_ui.targetedCharacter);
            _ui.ShowBomb(_ui.targetedCharacter);
            Debug.Log("폭발물 설치");
        }
    }

    // 폭발물 해제
    public void DoExplosionDiffuse(Explosion _e)
    {
        if (battleController.nowPlayCharacter)
        {
            _e.ExplosionDiffuse(battleController.nowPlayCharacter);
        }
        else
        {
            Debug.Log("지금은 캐릭터의 턴이 아니라 할 수 없습니다.");
        }
    }
}