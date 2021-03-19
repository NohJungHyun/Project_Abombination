﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleUIManager : MonoBehaviour
{
    public UItoShowBombInfo uitoShowBomb;
    public UItoShowExplosionInfo uItoShowExplosion;
    // public ActBar actBar;

    // public Image characterImage; //캐릭터의 스프라이트 정보를 가져와 출력하는 스프라이트
    // public Image hpBar; //캐릭터의 체력 바를 출력
    // public Image[] actionPointBar; //캐릭터가 지닌 액션 포인트를 의미. 

    // public delegate void UIControllor();
    // public UIControllor uIControllor = null;

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
        // characterBattleAction = GameObject.Find("BattleController").GetComponent<CharacterBattleAction>();
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

    public void GetBombPanel(List<Bomb> _bombs, BattleController _battle)
    {
        if (bombUI.activeInHierarchy) return;

        characterActUI.SetActive(false);
        bombUI.SetActive(true);
        Debug.Log("????");

        if (_bombs.Count <= bombUI.GetComponentsInChildren<Button>().Length)
        {
            for (int u = 0; u < _bombs.Count; u++)
            {
                int uiIndex = u;

                bombButtons.Add(bombUI.GetComponentsInChildren<Button>()[uiIndex]);
                bombButtons[uiIndex].onClick.RemoveAllListeners();
                bombButtons[uiIndex].image.sprite = _bombs[uiIndex].bombImage;

                CreateBombListInUI(_bombs, _battle, uiIndex);
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
                bombButtons[uiIndex].image.sprite = _temp[uiIndex].characterInfo.characterImage;

                DetectedCharactersListInUi(_temp, uiIndex);
            }
        }
    }

    // 현재 캐릭터가 지닌 폭탄 목록을 UI에 출력 및 버튼 이벤트 추가.
    public void CreateBombListInUI(List<Bomb> _bombs, BattleController _battle, int _u)
    {
        bombButtons[_u].onClick.AddListener(() => _battle.bombManager.CreateBombtoButtonClick(_battle.nowPlayCharacter,
                _bombs[_u].setBomb.isNeedSetup));
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
        bombButtons[u].onClick.AddListener(() => uitoShowBomb.ShowBomb(_characters[u]));
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

    // public void CloseCurUI(List<Button> _buttons)
    // {
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         if (EventSystem.current.IsPointerOverGameObject())
    //         {
    //             ActivateActionUI(true);
    //             // for (int i = 0; i < _buttons.Count; i++)
    //             // {
    //             //     _buttons[i].onClick.RemoveAllListeners();
    //             //     _buttons[i].image.sprite = null;
    //             //     _buttons[i].gameObject.SetActive(false);
    //             // }
    //         }
    //     }
    // }

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
}

