using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionPointUI : MonoBehaviour
{
    public TextMeshProUGUI actionPointText;

    // Start is called before the first frame update
    void Start()
    {
        actionPointText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BattleController.instance.GetNowPlayCharacter())
            actionPointText.text = BattleController.instance.GetNowPlayCharacter().actionPoint.ToString() + " / " + BattleController.instance.GetNowPlayCharacter().GetCharacterInfo().maxActionPoint.ToString();
        else
            actionPointText.text = " ";
    }
}
