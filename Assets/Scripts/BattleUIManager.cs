﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public Temp_Character temp_Character;
    // 폭탄의 상태 관리, 설치 등을 통제하고자 제작.
    public BombManager bombManager;

    // public Image characterImage; //캐릭터의 스프라이트 정보를 가져와 출력하는 스프라이트
    // public Image hpBar; //캐릭터의 체력 바를 출력
    // public Image[] actionPointBar; //캐릭터가 지닌 액션 포인트를 의미. 

    public delegate void UIControllor();
    public UIControllor uIControllor = null;

    [Header("캐릭터 턴일 때 띄울 UI")]
    public GameObject characterActUI;

    [Header("캐릭터 턴일 때 폭탄 제작에 띄울 UI")]
    public GameObject createBombUI;

    [Header("캐릭터가 지닌 폭발물 목록을 보여줄 때 띄울 UI")]
    public GameObject showExplosionListUI;

    [Header("현재 전장에 있는 폭탄에 대한 정보를 보여줄 때 띄울 UI")]
    public GameObject showBombContidion;
    public Text bombName;
    public Text bombCount;
    public Sprite bombImage;
    public Button bombDiffuseButton;
    public Button[] explosionBomb = new Button[10];
    

    public List<Button> bombButtons = new List<Button>(20);
    // public List<Bomb> bombs = new List<Bomb>();

    // Start is called before the first frame update
    void Start()
    {
        characterActUI.SetActive(false);
        createBombUI.SetActive(false);
    }

    public void ActivateActionUI()
    {
        characterActUI.SetActive(true);
        createBombUI.SetActive(false);
    }

    public void GetBombPanel()
    {
        characterActUI.SetActive(false);
        createBombUI.SetActive(true);
    }

    // 현재 캐릭터가 지닌 폭탄 목록을 UI에 출력 및 버튼 이벤트 추가.
    public void SetBombListinUI(Temp_Character _t)
    {
        if (_t)
        {
            temp_Character = _t;

            if (temp_Character.canSetBombs.Count > 0)
            {
                if (temp_Character.canSetBombs.Count < createBombUI.GetComponentsInChildren<Button>().Length)
                {
                    // for (int u = 0; u < createBombUI.GetComponentsInChildren<Button>().Length - 1; u++)
                    for (int u = 0; u < temp_Character.canSetBombs.Count; u++)
                    {
                        int uiIndex = u;
                        Debug.Log(uiIndex);

                        bombButtons.Add(createBombUI.GetComponentsInChildren<Button>()[uiIndex]);
                        // 버튼 이미지
                        bombButtons[uiIndex].image.sprite = _t.canSetBombs[uiIndex].bombImage;
                        // 버튼 클릭 이미지 추가.
                        bombButtons[uiIndex].onClick.AddListener(() => bombManager.SetBombinHand(temp_Character.canSetBombs[uiIndex], temp_Character));
                    }
                }
            }
        }
    }

    // 현재 선택한 폭탄의 상태를 확인하기 위해 만든 함수.
    public void ExhibitBombCondition()
    {

    }

    // 캐릭터가 지닌 폭발물 목록을 보여주기 위해 만든 함수.
    public void ExhibitExlposionList(Temp_Character _t)
    {
        if (_t.canSetExplosions.Count > 0)
        {
            Button[] bt = showExplosionListUI.GetComponentsInChildren<Button>();
            // 버튼의 이미지를 폭발물의 이미지로 대체하기 전, 버튼의 수가 캐릭터가 지닌 개수보다 많은 지 확인.
            if (bt.Length >= _t.canSetExplosions.Count)
            {
                for (int e = 0; e < _t.canSetExplosions.Count; e++)
                {
                    bt[e].GetComponent<Image>().sprite = _t.canSetExplosions[e].exploImage;
                    bt[e].GetComponent<Text>().text = _t.canSetExplosions[e].exploCountDown.ToString();
                }
            }
        }
    }
}
