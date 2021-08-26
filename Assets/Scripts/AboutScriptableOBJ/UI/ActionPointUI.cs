using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPointUI : BaseUIStorage
{
    public TextMeshProUGUI actionPointText;

    [SerializeField]
    NowTurnCharacterManager nowTurnCharacterManager;

    // Start is called before the first frame update
    void Start()
    {
        actionPointText = GetComponentInChildren<TextMeshProUGUI>();
        SearchWithRayCast.characterClick += SetCharacterInfo;
    }
    public override void InitUI()
    {

    }

    void SetCharacterInfo(Temp_Character temp_Character)
    {
        // if (nowTurnCharacterManager && nowTurnCharacterManager.GetNowCharacter())
        // {
        //     print(nowTurnCharacterManager.GetNowCharacter().GetCharacterInfo().curActionPoint.ToString());
        //     actionPointText.text = nowTurnCharacterManager.GetNowCharacter().GetCharacterInfo().curActionPoint.ToString() + " / " + nowTurnCharacterManager.GetNowCharacter().GetCharacterInfo().maxActionPoint.ToString();
        // }
        // else
        // {
        //     actionPointText.text = " ";
        // }

        if (temp_Character)
            actionPointText.text = temp_Character.GetCharacterInfo().curActionPoint.ToString() + " / " + temp_Character.GetCharacterInfo().maxActionPoint.ToString();
        else
            actionPointText.text = " ";
        
    }
    
}
