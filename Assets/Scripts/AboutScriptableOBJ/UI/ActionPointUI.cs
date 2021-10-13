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
        // SearchWithRayCast.characterClick += SetCharacterInfo;
    }
    public override void InitUI()
    {

    }

    public void SetActionPointText(Temp_Character temp_Character)
    {
        if (temp_Character)
            actionPointText.text = temp_Character.ActionPointController.CurActionPoint.ToString() + " / " + temp_Character.GetCharacterInfo().maxActionPoint.ToString();
        else
            actionPointText.text = " ";
        
    }
    
}
