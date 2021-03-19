using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIState : MonoBehaviour
{
    public Sprite basicSprite;
    public abstract void EnterState(GameObject UISelf);
    public abstract void PlayState(GameObject UISelf);
    public abstract void ExitState(GameObject UISelf);
    public abstract void UpdateCurUI(GameObject UISelf);

    public virtual void ForceToClose(GameObject UISelf)
    {
        UISelf.gameObject.SetActive(false);
    }

    public virtual void ClearEventInButtons(GameObject UISelf)
    {
        Button[] buttons = UISelf.gameObject.GetComponentsInChildren<Button>();

        for (int b = 0; b < buttons.Length; b++)
        {
            buttons[b].onClick.RemoveAllListeners();
            buttons[b].image.sprite = basicSprite;
            if(buttons[b].GetComponentInChildren<Text>())
            {
                buttons[b].GetComponentInChildren<Text>().text = " ";
            }   
        }
    }
}
