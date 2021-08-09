using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoUI : MonoBehaviour
{
    public static CharacterInfoUI instance;

    [Header("캐릭터 기본 정보 파트")]
    public Image characterInfoBG;
    public Image hpBar;
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

    public void ChangeCharacterBasicInfo(Temp_Character _Character)
    {
        characterInfoBG.sprite = _Character.GetCharacterInfo().portrait;
        // hpBar.
    }
}
