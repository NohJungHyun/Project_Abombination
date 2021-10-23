﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleUIManager : MonoBehaviour
{
    public delegate void ButtonDele();

    public Button turnEndButton;
    public QuickBarUI quickBarUI;

    // public List<Button> bombButtons = new List<Button>(20);

    [Header("TargetedCharacter UI")]
    // public BombModifier bombModifier;

    [Header("커맨드 포인트 표현 UI")]
    // public SelectCharacterUI selectCharacterUI;
    public GameObject selectCharacterUIObj;
    public AlarmBattleStateSwitch alarmBattleStateSwitch;
    // public Temp_Character temp_Character;

    void Awake()
    {
        // alarmBattleStateSwitch = FindObjectOfType<AlarmBattleStateSwitch>();  

        // bombModifier.ShowUI(false);
        selectCharacterUIObj.SetActive(false);
        alarmBattleStateSwitch.ShowUI(false);  

    }

    public void ChangeButtonToPhaseEndButton(ButtonDele dele)
    {
        turnEndButton.onClick.RemoveAllListeners();

        turnEndButton.onClick.AddListener(() => dele());
        ChangeButtonColor(turnEndButton, Color.red);
        turnEndButton.GetComponentInChildren<Text>().text = "Jump to \n PhaseEnd";
    }

    public static void ChangeButtonColor(Button button, Color color)
    {
        button.image.color = color;
    }

    // public void ActivateActionUI(bool isOn)
    // {
    //     // characterActUI.SetActive(isOn);
    //     // bombUI.SetActive(!isOn);
    // }

    // public void OnOffUIManager(bool _onOff)
    // {
    //     this.gameObject.SetActive(_onOff);
    // }

    // public void ShowBombInfoUI()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         if (!EventSystem.current.IsPointerOverGameObject())
    //         {

    //             if (SearchWithRayCast.hit.collider != null && SearchWithRayCast.hit.collider.GetComponent<Temp_Character>()) //hit.collider != null && 
    //             {
    //                 uitoShowBomb.OnOffShowBombUI(true);
    //                 uitoShowBomb.CheckBomb(SearchWithRayCast.hit.collider.GetComponent<Temp_Character>());
    //             }
    //             else
    //             {
    //                 uitoShowBomb.OnOffShowBombUI(false);
    //             }
    //         }
    //     }
    //     else if (Input.GetMouseButtonDown(1))
    //     {
    //         CloseUI();
    //     }
    // }

    // public void SetModifyAbombinationAction()
    // {
    //     SetCharacterAction(new ModifyAbombination(BattleController.instance));
    // }

    // public void SetSelectTarget()
    // {
    //     SetCharacterAction(new SelectTarget(BattleController.instance));
    // }

    // public void SetCreateBombAction()
    // {
    //     SetCharacterAction(new CreateBomb(BattleController.instance));
    // }

    // 폭탄 패널 출력.
    // public void GetBombPanel()
    // {
    //     Debug.Log("qqqqq");
    //     if (bombUI.activeInHierarchy) return;

    //     List<Bomb> bombList = BattleController.instance.nowPlayCharacter.canSetBombs;

    //     characterActUI.SetActive(false);
    //     bombUI.SetActive(true);

    //     if (bombList.Count <= bombUI.GetComponentsInChildren<Button>().Length)
    //     {
    //         for (int u = 0; u < bombList.Count; u++)
    //         {
    //             int uiIndex = u;

    //             bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
    //             bombButtons[uiIndex].onClick.RemoveAllListeners();
    //             bombButtons[uiIndex].image.sprite = bombList[uiIndex].bombImage;

    //             SetCreateBombAction(bombList, uiIndex);
    //         }
    //     }
    // }

    // 현재 캐릭터가 제작할 수 있는 폭탄 목록을 UI에 출력 및 버튼 이벤트 추가. //_battle.nowPlayCharacter
    // public void SetCreateBombAction(List<Bomb> _bombs, int _u)
    // {
    //     // bombButtons[_u].onClick.AddListener(() => ScriptableObject.CreateInstance<CreateBomb
    //     //     (BattleController.instance.GetTemp_Character(), BattleController.instance)>().CreateBombtoButtonClick(_bombs[_u]);

    //     CreateBomb cb = new CreateBomb(BattleController.instance);
    //     bombButtons[_u].onClick.AddListener(() => cb.ControllUI(this));
    //     bombButtons[_u].onClick.AddListener(() => cb.CreateBombtoButtonClick(_bombs[_u]));

    // }

    // 폭탄을 지닌 대상들 선별
    // public void GetCharacterPanel(List<Temp_Character> _temp, BattleController _battle)
    // {
    //     if (bombUI.activeInHierarchy) return;

    //     characterActUI.SetActive(false);
    //     bombUI.SetActive(true);

    //     if (_temp.Count <= bombUI.GetComponentsInChildren<Button>().Length)
    //     {
    //         for (int u = 0; u < _temp.Count; u++)
    //         {
    //             int uiIndex = u;

    //             bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
    //             bombButtons[uiIndex].onClick.RemoveAllListeners();
    //             bombButtons[uiIndex].image.sprite = _temp[uiIndex].info.characterImage;

    //             DetectedCharactersListInUi(_temp, uiIndex);
    //         }
    //     }
    // }

    // public void DetectedCharactersListInUi(List<Temp_Character> _characters, int _u)
    // {
    //     int u = _u;
    //     bombButtons[u].onClick.AddListener(() => ShowAdditionalBombPanal(_characters[u]));
    //     // bombButtons[_u].onClick.AddListener(() => _battle.doZoom = false);
    //     // bombButtons[u].onClick.AddListener(() => temp_Character = _characters[u]);

    //     uItoShowExplosion.gameObject.SetActive(true);
    //     bombButtons[u].onClick.AddListener(() => uItoShowExplosion.ExhibitExploButtons());

    //     // uitoShowBomb.GetBattleUIManager(this);
    //     bombButtons[u].onClick.AddListener(() => uitoShowBomb.OnOffShowBombUI(true));
    //     bombButtons[u].onClick.AddListener(() => uitoShowBomb.CheckBomb(_characters[u]));
    //     bombButtons[u].onClick.AddListener(() => Debug.Log(_characters[u].name));
    // }

    // public void ShowAdditionalBombPanal(Temp_Character _temp)
    // {
    //     additionalBombUI.gameObject.SetActive(true);
    //     for (int a = 0; a < additionalBombUI.GetComponentsInChildren<Button>().Length; a++)
    //     {
    //         Button b = additionalBombUI.GetComponentsInChildren<Button>()[a];
    //         if (a < _temp.haveBombs.Count)
    //         {
    //             int additionalEvent = a;
    //             b.image.sprite = _temp.haveBombs[additionalEvent].bombImage;
    //             // additionalBombPanal[additionalEvent].onClick.AddListener(() => CharacterBattleAction.instance.EditBomb());
    //         }
    //     }
    // }

    // public void SetEventToActUI(PlayerTurnDoState _playerTurnDoState)
    // {
    //     for (int b = 0; b < _playerTurnDoState.characterActions.Count; b++)
    //     {
    //         int actIndex = b;
    //         characterActUI.GetComponentsInChildren<Button>()[actIndex].onClick.AddListener(() => _playerTurnDoState.SetNowAction(_playerTurnDoState.characterActions[actIndex]));
    //         characterActUI.GetComponentsInChildren<Button>()[actIndex].onClick.AddListener(() => _playerTurnDoState.characterActions[actIndex].ControllUI(this));
    //     }
    // }

}

