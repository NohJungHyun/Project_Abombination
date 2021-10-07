using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public abstract class BaseUIStorage : MonoBehaviour
{
    protected BattleUIManager battleUIManager;
    // 본격적으로 받아온 정보를 UI에 옮기는 함수
    public virtual void ShowUI(bool isOn)
    {
        // this.enabled = isOn;
        gameObject.SetActive(isOn);
        print(this.enabled);
    }
    public virtual void InitUI()
    {
        battleUIManager = GameObject.FindObjectOfType<BattleUIManager>();
    }
}
