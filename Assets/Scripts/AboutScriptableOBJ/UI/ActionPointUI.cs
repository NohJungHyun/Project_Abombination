using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPointUI : MonoBehaviour
{
    public TextMeshProUGUI actionPointText;
    
    [SerializeField]
    NowTurnCharacterManager nowTurnCharacterManager;

    // Start is called before the first frame update
    void Start()
    {
        actionPointText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nowTurnCharacterManager && nowTurnCharacterManager.GetNowCharacter())
            actionPointText.text = nowTurnCharacterManager.GetNowCharacter().GetCharacterInfo().curActionPoint.ToString() + " / " + nowTurnCharacterManager.GetNowCharacter().GetCharacterInfo().maxActionPoint.ToString();
        else
            actionPointText.text = " ";
    }
}
