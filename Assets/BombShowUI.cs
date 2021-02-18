using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombShowUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
