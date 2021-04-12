using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/CreateBomb")]
public class CreateBomb : CharacterAction, ISelectTarget
{
    public Temp_Character bombOwner;
    public bool canSetBomb = true;
    public static Bomb targetBomb;

    static SetBombPositions bombPosition;

    GameObject bombUI;
    List<Button> bombButtons = new List<Button>(10);
    LayerMask layerMask = LayerMask.GetMask("Characters");

    public CreateBomb(BattleController _battleController) : base(_battleController)
    {
        canSetBomb = true;
        battleController = BattleController.instance;
        nowTurnCharacter = _battleController.GetNowPlayCharacter();

        if(battleController.areaIndicatorStorage)
        battleController.areaIndicatorStorage.ModifyIndicatorSize(battleController.areaIndicatorStorage.circleIndicator, nowTurnCharacter.info.characterDetectRange + 1);
    }

    public override void EnterCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        BattleController.instance.SetCharacterAction(this);
        // _BattleUI.GetBombPanel();

        bombUI = _BattleUI.bombUI;
        bombButtons = _BattleUI.bombButtons;

        GetBombPanel(_BattleUI);
    }

    public override void ActCharacterAction()
    {
        if (bombPosition)
        {
            battleController.areaIndicatorStorage.circleIndicator.SetActive(false);
            bombPosition.DecideSetWay(this);
        }
        else
        {
            battleController.areaIndicatorStorage.circleIndicator.SetActive(true);
            battleController.areaIndicatorStorage.MoveIndicator(battleController.areaIndicatorStorage.circleIndicator, nowTurnCharacter.transform.position);
            SelectTargetInRange();
        }
    }

    public override void ExitCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public void SelectTargetInRange()
    {
        float hitPointX = SearchWithRayCast.GetHitPoint().x;
        float hitPointZ = SearchWithRayCast.GetHitPoint().z;
        float clampX = Mathf.Clamp(hitPointX, nowTurnCharacter.transform.position.x - nowTurnCharacter.info.characterDetectRange, nowTurnCharacter.transform.position.x + nowTurnCharacter.info.characterDetectRange);
        float clampZ = Mathf.Clamp(hitPointZ, nowTurnCharacter.transform.position.z - nowTurnCharacter.info.characterDetectRange, nowTurnCharacter.transform.position.z + nowTurnCharacter.info.characterDetectRange);

        Vector3 clampVector = new Vector3(clampX, nowTurnCharacter.transform.position.y, clampZ);
        SearchWithRayCast.SetLayer(layerMask);
        
        if (SearchWithRayCast.GetHitSomething() && Input.GetMouseButtonDown(0))
        {
            // 지정 가능 범위 밖의 대상을 선택할 경우.
            if (Vector3.Distance(SearchWithRayCast.GetHitCharacter().transform.position, bombOwner.GetCharacterPos()) > Vector3.Distance(clampVector, bombOwner.GetCharacterPos()))
            {
                Debug.Log("흠?");
            }
            else
            {
                Debug.Log("지정 범위 내 대상 발견");
            }
        }
    }

    // 폭탄 패널 출력.
    public void GetBombPanel(BattleUIManager _BattleUI)
    {
        Debug.Log("qqqqq");
        if (bombUI.activeInHierarchy) return;

        List<Bomb> bombList = nowTurnCharacter.canSetBombs;

        _BattleUI.ActivateActionUI(false);

        if (bombList.Count <= bombUI.GetComponentsInChildren<Button>().Length)
        {
            for (int u = 0; u < bombList.Count; u++)
            {
                int uiIndex = u;

                bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
                bombButtons[uiIndex].onClick.RemoveAllListeners();
                bombButtons[uiIndex].image.sprite = bombList[uiIndex].bombImage;

                bombButtons[uiIndex].onClick.AddListener(() => CreateBombtoButtonClick(bombList[uiIndex]));

            }
        }
    }

    public void CreateBombtoButtonClick(Bomb _bomb)
    {
        // 생성자로 지정되지 않을 것을 대비해 사용.
        if (!battleController)
            battleController = BattleController.instance;
        if (!nowTurnCharacter)
            bombOwner = BattleController.instance.GetNowPlayCharacter();

        // CharacterBattleAction.nowAction = this;
        canSetBomb = true;
        targetBomb = _bomb;

        bombPosition = _bomb.setBombPosition;
        bombPosition.createBomb = this;

        Debug.Log("폭탄 정보 확인: " + bombPosition);
    }
}
