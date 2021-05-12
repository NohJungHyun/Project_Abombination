using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CanSettable : MonoBehaviour
{
    public abstract void SetToButton(Button _quickButton);

    public abstract ICanSetButtons GetCanSet();

    public abstract Sprite GetSprite();
}
