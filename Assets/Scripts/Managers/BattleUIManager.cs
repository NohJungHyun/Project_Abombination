﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleUIManager : MonoBehaviour
{
    // public CharacterBattleAction characterBattleAction;
    
    public UItoShowBombInfo uitoShowBomb;
    public UItoShowExplosionInfo uItoShowExplosion;

    [Header("캐릭터가 할 수 있는 액션 UI")]
    public GameObject characterActUI;

    [Header("캐릭터 턴일 때 설치가능한 폭탄 UI")]
    public GameObject bombUI;

    public GameObject additionalBombUI;

    public List<Button> bombButtons = new List<Button>(20);
    // public Temp_Character temp_Character;


    void Start()
    {
        characterActUI.SetActive(false);
        bombUI.SetActive(false);
        additionalBombUI.SetActive(false);
    }

    public void ActivateActionUI(bool isOn)
    {
        characterActUI.SetActive(isOn);
        bombUI.SetActive(!isOn);
    }

    public void GetActCharacter()
    {
        // actBar.SetActImages();
    }

    // 폭탄 패널 출력.
    public void GetBombPanel()
    {
        Debug.Log("qqqqq");
        if (bombUI.activeInHierarchy) return;

        List<Bomb> bombList = BattleController.instance.nowPlayCharacter.canSetBombs;

        characterActUI.SetActive(false);
        bombUI.SetActive(true);

        if (bombList.Count <= bombUI.GetComponentsInChildren<Button>().Length)
        {
            for (int u = 0; u < bombList.Count; u++)
            {
                int uiIndex = u;

                bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
                bombButtons[uiIndex].onClick.RemoveAllListeners();
                bombButtons[uiIndex].image.sprite = bombList[uiIndex].bombImage;

                CreateBombListInUI(bombList, uiIndex);
            }
        }
    }

    // 폭탄을 지닌 대상들 선별
    public void GetCharacterPanel(List<Temp_Character> _temp, BattleController _battle)
    {
        if (bombUI.activeInHierarchy) return;

        characterActUI.SetActive(false);
        bombUI.SetActive(true);

        if (_temp.Count <= bombUI.GetComponentsInChildren<Button>().Length)
        {
            for (int u = 0; u < _temp.Count; u++)
            {
                int uiIndex = u;

                bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
                bombButtons[uiIndex].onClick.RemoveAllListeners();
                bombButtons[uiIndex].image.sprite = _temp[uiIndex].info.characterImage;

                DetectedCharactersListInUi(_temp, uiIndex);
            }
        }
    }

    // 현재 캐릭터가 제작할 수 있는 폭탄 목록을 UI에 출력 및 버튼 이벤트 추가. //_battle.nowPlayCharacter
    public void CreateBombListInUI(List<Bomb> _bombs, int _u)
    {
        // bombButtons[_u].onClick.AddListener(() => ScriptableObject.CreateInstance<CreateBomb
        //     (BattleController.instance.GetTemp_Character(), BattleController.instance)>().CreateBombtoButtonClick(_bombs[_u]);
        bombButtons[_u].onClick.AddListener(() => new CreateBomb(BattleController.instance).CreateBombtoButtonClick((_bombs[_u])));// ScriptableObject.CreateInstance<CreateBomb>().CreateBombtoButtonClick(_bombs[_u]));
    }

    public void DetectedCharactersListInUi(List<Temp_Character> _characters, int _u)
    {
        int u = _u;
        bombButtons[u].onClick.AddListener(() => ShowAdditionalBombPanal(_characters[u]));
        // bombButtons[_u].onClick.AddListener(() => _battle.doZoom = false);
        // bombButtons[u].onClick.AddListener(() => temp_Character = _characters[u]);

        uItoShowExplosion.gameObject.SetActive(true);
        bombButtons[u].onClick.AddListener(() => uItoShowExplosion.ExhibitExploButtons());

        // uitoShowBomb.GetBattleUIManager(this);
        bombButtons[u].onClick.AddListener(() => uitoShowBomb.OnOffShowBombUI(true));
        bombButtons[u].onClick.AddListener(() => uitoShowBomb.CheckBomb(_characters[u]));
        bombButtons[u].onClick.AddListener(() => Debug.Log(_characters[u].name));
    }

    public void ShowAdditionalBombPanal(Temp_Character _temp)
    {
        additionalBombUI.gameObject.SetActive(true);
        for (int a = 0; a < additionalBombUI.GetComponentsInChildren<Button>().Length; a++)
        {
            Button b = additionalBombUI.GetComponentsInChildren<Button>()[a];
            if (a < _temp.haveBombs.Count)
            {
                int additionalEvent = a;
                b.image.sprite = _temp.haveBombs[additionalEvent].bombImage;
                // additionalBombPanal[additionalEvent].onClick.AddListener(() => CharacterBattleAction.instance.EditBomb());
            }
        }
    }

    public void CloseUI()
    {
        if (uitoShowBomb || uItoShowExplosion || additionalBombUI)
        {

            uitoShowBomb.gameObject.SetActive(false);
            uItoShowExplosion.gameObject.SetActive(false);
            additionalBombUI.SetActive(false);
        }

        if (bombUI)
        {
            ActivateActionUI(true);
        }
        else
        {
            ActivateActionUI(false);
        }
    }

    public void OnOffUIManager(bool _onOff)
    {
        this.gameObject.SetActive(_onOff);
    }

    public void ShowBombInfoUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {

                if (SearchWithRayCast.hit.collider != null && SearchWithRayCast.hit.collider.GetComponent<Temp_Character>()) //hit.collider != null && 
                {
                    uitoShowBomb.OnOffShowBombUI(true);
                    uitoShowBomb.CheckBomb(SearchWithRayCast.hit.collider.GetComponent<Temp_Character>());
                }
                else
                {
                    uitoShowBomb.OnOffShowBombUI(false);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CloseUI();
        }

        // if (CreateBomb.setupGo)
        // {
        //     _battleController.cameraController.SetZoomCondition(false);
        //     CreateBomb.ReadytoSetup(SearchWithRayCast.hit.point, _battleController.nowPlayCharacter);
        // }
    }

    public void SetEventToActUI(CharacterBattleAction _characterBattleAction)
    {
        for (int b = 0; b < _characterBattleAction.characterActions.Count; b++)
        {
            int actIndex = b;
            characterActUI.GetComponentsInChildren<Button>()[actIndex].onClick.AddListener(() => _characterBattleAction.characterActions[actIndex].ControllUI(this));
        }
    }
}

