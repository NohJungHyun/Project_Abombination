﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour
{
    public static CharacterInfoUI instance;
    public GameObject characterInfoBG;
    public List<Button> quickBarButtons;

    public Text actionPointText;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionPointText.text = " ";
        ResetButton();
    }

    void ResetButton()
    {
        for (int b = 0; b < quickBarButtons.Count; b++)
        {
            quickBarButtons[b].onClick.RemoveAllListeners();
            quickBarButtons[b].image.sprite = null;
        }
    }

    public void FillWithBomb(List<Bomb> _list)
    {
        for (int b = 0; b < _list.Count; b++)
        {
            // quickBarButtons[b].onClick.RemoveAllListeners();
            quickBarButtons[b].image.sprite = _list[b].GetSprite();
            quickBarButtons[b].onClick.AddListener(() => _list[b].Use());
        }
    }

    // public void FillWithEvent(List<ICanSetButtons> _list)
    // {
    //     for (int b = 0; b < _list.Count; b++)
    //     {
    //         quickBarButtons[b].onClick.RemoveAllListeners();
    //         quickBarButtons[b].image.sprite = _list[b].GetSprite();
    //         quickBarButtons[b].onClick.AddListener(() => _list[b].Use());
    //     }
    // }
}
