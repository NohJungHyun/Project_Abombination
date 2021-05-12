using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICanSetButtons: IUsable
{
    void SetToButton(Button _quickButton);

    ICanSetButtons GetCanSet();

    Sprite GetSprite();
}
