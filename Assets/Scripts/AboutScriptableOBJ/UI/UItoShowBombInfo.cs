using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItoShowBombInfo : BaseUIStorage
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

    public override void InitUI()
    {

    }

    public void SetDiffuseEvent(Temp_Character _Character)
    {
        DiffuseBomb diffuseEvent = new DiffuseBomb(BattleController.instance);
        bombDiffuseButton.onClick.AddListener(() => diffuseEvent.ControllUI(battleUIManager));
        bombDiffuseButton.onClick.AddListener(() => diffuseEvent.ExitState());
    }

    public void SetBoomEvent(Temp_Character _Character)
    {
        BoomBomb boomEvent = new BoomBomb(BattleController.instance);
        bombBoomButton.onClick.AddListener(() => boomEvent.ControllUI(battleUIManager));
        bombBoomButton.onClick.AddListener(() => boomEvent.ExitState());
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
