using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoUI : BaseUIStorage
{
    public static CharacterInfoUI instance;

    [Header("캐릭터 기본 정보 파트")]
    public Image characterInfoBG;
    public Slider hpBar;
    public Text characterName;
    public Sprite basicSprtie;

    [Header("퀵슬롯")]
    public QuickBarUI quickBarUI;

    [Header("액션 포인트 파트")]
    public ActionPointUI actionPointUI;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionPointUI = GetComponentInChildren<ActionPointUI>();
    }

    private void Update()
    {
        if(BattleController.instance.GetState() is SelectActCharacter)
        {
            if(SearchWithRayCast.selectedCharacter)
                ChangeCharacterBasicInfo(SearchWithRayCast.selectedCharacter);
        }
        else
            if(NowTurnCharacterManager.nowPlayCharacter)
                ChangeCharacterBasicInfo(NowTurnCharacterManager.nowPlayCharacter);
    }

    public override void InitUI()
    {

    }

    public void ChangeCharacterBasicInfo(Temp_Character _Character)
    {
        characterInfoBG.sprite = _Character.GetCharacterInfo().portrait;
        characterName.text = _Character.GetCharacterInfo().GetName();
        hpBar.maxValue = _Character.GetCharacterInfo().maxHP;
        hpBar.value = _Character.curHP;

        actionPointUI.SetActionPointText(_Character);
    }
}
