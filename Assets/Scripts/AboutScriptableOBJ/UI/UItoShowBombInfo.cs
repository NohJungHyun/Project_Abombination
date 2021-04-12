using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItoShowBombInfo : MonoBehaviour
{
    // public CharacterBattleAction characterBattleAction;

    [Header("현재 전장에 있는 폭탄에 대한 정보를 보여줄 때 띄울 UI")]
    // public GameObject showBombContidition;
    public Text bombName;
    public Text bombCount;
    public Image bombImage;
    public Button bombDiffuseButton;
    public Button bombBoomButton;
    public Button afterBomb, beforeBomb;
    public Button[] explosionsinBomb = new Button[10];

    // public bool isUIOn = false;
    public int indexBomb = 0;

    public delegate void dele(Temp_Character _temp);
    public dele CheckBomb;
    public Temp_Character targetedCharacter;
    public BattleUIManager battleUIManager;

    void Awake()
    {
        // ShowBomb = new dele(GetInfofromRaycast);
        CheckBomb = new dele(CheckBombList);
        CheckBomb += new dele(GetInfofromRaycast);
        CheckBomb += new dele(ExhibitBombCondition);
        CheckBomb += new dele(ExhibitExplosionsCondition);
    }

    public void CheckBombList(Temp_Character _temp)
    {
        ClearAllEvents();

        if (targetedCharacter && !targetedCharacter.Equals(_temp))
        {
            indexBomb = 0;
        }

        targetedCharacter = _temp;

        if (_temp.haveBombs.Count <= 0)
        {
            print("CheckBombList");

            bombName.text = " ";
            bombCount.text = " ";
            bombImage.sprite = null; // = basicSprite;

            for (int b = 0; b < explosionsinBomb.Length; b++)
            {
                ClearButton(explosionsinBomb[b]);
            }
        }
    }

    // raycast로 부터 정보를 받기
    public void GetInfofromRaycast(Temp_Character _t)
    {
        print("GetInfofromRaycast");

        if (indexBomb < _t.haveBombs.Count - 1)
        {
            afterBomb.onClick.AddListener(() => indexBomb++);
            afterBomb.onClick.AddListener(() => CheckBomb(_t));
            afterBomb.interactable = true;
        }
        else
            afterBomb.interactable = false;

        if (indexBomb > 0)
        {
            beforeBomb.onClick.AddListener(() => indexBomb--);
            beforeBomb.onClick.AddListener(() => CheckBomb(_t));
            beforeBomb.interactable = true;
        }
        else
            beforeBomb.interactable = false;

    }

    // 현재 선택한 폭탄의 상태를 확인하기 위해 만든 함수.
    public void ExhibitBombCondition(Temp_Character _t)
    {
        print("ExhibitBombCondition");
        if (_t.haveBombs.Count <= 0) return;

        bombName.text = _t.haveBombs[indexBomb].bombName;
        bombCount.text = _t.haveBombs[indexBomb].bombCurCountDown.ToString();
        bombImage.sprite = _t.haveBombs[indexBomb].bombImage;

        if (BattleController.instance.nowPlayCharacter)
        {
            SetDiffuseEvent(targetedCharacter);
            SetBoomEvent(targetedCharacter);
        }
    }

    public void ExhibitExplosionsCondition(Temp_Character _t)
    {
        print("ExhibitExplosionsCondition");
        if (_t.haveBombs.Count <= 0) return;

        for (int e = 0; e < _t.haveBombs[indexBomb].explosionList.Count; e++) // 이거는 폭탄 내 폭발물 개수 파악
        {
            int explosionCheck = e;

            explosionsinBomb[explosionCheck].image.sprite = _t.haveBombs[indexBomb].explosionList[explosionCheck].exploImage;
            explosionsinBomb[explosionCheck].GetComponentInChildren<Text>().text = _t.haveBombs[indexBomb].explosionList[explosionCheck].exploCountDown.ToString();

            if (BattleController.instance.nowPlayCharacter)
                explosionsinBomb[explosionCheck].onClick.AddListener(() => RemoveExplosion.DoExplosionDiffuse(_t.haveBombs[indexBomb].explosionList[explosionCheck]));
        }
    }

    public void SetDiffuseEvent(Temp_Character _Character)
    {
        DiffuseBomb diffuseEvent = new DiffuseBomb(BattleController.instance);
        bombDiffuseButton.onClick.AddListener(() => diffuseEvent.ControllUI(battleUIManager));
        bombDiffuseButton.onClick.AddListener(() => diffuseEvent.ActCharacterAction());
    }

    public void SetBoomEvent(Temp_Character _Character)
    {
        BoomBomb boomEvent = new BoomBomb(BattleController.instance);
        bombBoomButton.onClick.AddListener(() => boomEvent.ControllUI(battleUIManager));
        bombBoomButton.onClick.AddListener(() => boomEvent.ActCharacterAction());
    }

    public void ClearAllEvents()
    {
        bombDiffuseButton.onClick.RemoveAllListeners();
        afterBomb.onClick.RemoveAllListeners();
        beforeBomb.onClick.RemoveAllListeners();

        if (explosionsinBomb.Length <= 0) return;

        for (int e = 0; e < explosionsinBomb.Length; e++)
        {
            ClearButton(explosionsinBomb[e]);
        }
    }

    public void ClearButton(Button _b)
    {
        _b.onClick.RemoveAllListeners();
        _b.image.sprite = null;
        _b.GetComponentInChildren<Text>().text = " ";
    }

    public void OnOffShowBombUI(bool _onOff)
    {
        this.gameObject.SetActive(_onOff);
    }
}
