using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CanSettable : ScriptableObject, IUsable
{
    public Temp_Character owner;


    public virtual void SetToButton(Button _quickButton)
    {
        _quickButton.onClick.AddListener(() => Use());
    }

    public abstract Sprite GetSprite();

    public IEnumerator Use()
    {
        Debug.Log("킹튼 사용함");
        yield return null;
    }
}
