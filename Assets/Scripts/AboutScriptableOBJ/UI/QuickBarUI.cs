using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickBarUI : MonoBehaviour
{
    public List<Button> quickButtons = new List<Button>(6);
    public List<ICanSetButtons> buttonsData = new List<ICanSetButtons>(6);

    public void SetEventToButtons(List<ICanSetButtons> _setButtons)
    {
        for (int b = 0; b < quickButtons.Count; b++)
        {
            _setButtons[b].SetToButton(quickButtons[b]);
            quickButtons[b].onClick.AddListener(() => _setButtons[b].Use());
        }
    }

    public void SetBombToButtons(List<Bomb> _setButtons)
    {
        for (int b = 0; b < quickButtons.Count; b++)
        {
            _setButtons[b].SetToButton(quickButtons[b]);
            quickButtons[b].onClick.AddListener(() => _setButtons[b].Use());
        }
    }

    public void SetItemToButtons(List<ItemData> _setButtons)
    {
        for (int b = 0; b < quickButtons.Count; b++)
        {
            _setButtons[b].SetToButton(quickButtons[b]);
            quickButtons[b].onClick.AddListener(() => _setButtons[b].Use());
        }
    }

    public void SetSkillToButtons(List<SkillData> _setButtons)
    {
        for (int b = 0; b < quickButtons.Count; b++)
        {
            _setButtons[b].SetToButton(quickButtons[b]);
            quickButtons[b].onClick.AddListener(() => _setButtons[b].Use());
        }
    }

    public void ResetButtons()
    {

    }

    public void ChangeOneButton()
    {

    }
}
