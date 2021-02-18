using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItoShowBombInfo : MonoBehaviour
{
    CharacterBattleAction characterBattleAction;

    [Header("현재 전장에 있는 폭탄에 대한 정보를 보여줄 때 띄울 UI")]
    public GameObject showBombContidition;
    public Text bombName;
    public Text bombCount;
    public Image bombImage;
    public Button bombDiffuseButton;
    public Button[] explosionsinBomb = new Button[10];

    public Canvas canvas;

    public bool isUIOn = false;

    public void Start()
    {
        characterBattleAction = GameObject.Find("BattleController").GetComponent<CharacterBattleAction>();
    }

    // raycast로 부터 정보를 받기
    public void GetInfofromRaycast(RaycastHit _h)
    {
        if (_h.collider.GetComponent<Bomb>())
        {
            if (!isUIOn)
            {
                Bomb b = _h.collider.GetComponent<Bomb>();
                
                showBombContidition.SetActive(true);
                ExhibitBombCondition(b);
            }
        }
    }

    // 현재 선택한 폭탄의 상태를 확인하기 위해 만든 함수.
    public void ExhibitBombCondition(Bomb _b)
    {
        bombDiffuseButton.onClick.RemoveAllListeners();

        bombName.text = _b.bombName;
        bombCount.text = _b.bombCountDown.ToString();
        bombImage.sprite = _b.bombImage;

        // DiffuseBomb(_b);
        bombDiffuseButton.onClick.AddListener(() => characterBattleAction.DiffuseBomb(_b.gameObject));
    }

    public void ExhibitExplosionsCondition(Bomb _b)
    {
        for (int e = 0; e < explosionsinBomb.Length; e++)
        {
            explosionsinBomb[e].image.sprite = _b.explosionList[e].exploImage;
            explosionsinBomb[e].image.GetComponentInChildren<Text>().text = _b.explosionList[e].exploCountDown.ToString();
        }
    }

    // 획일화된 코드 관리를 위해 characterBattleAction에서 diffuseBomb을 관리.
    // public void DiffuseBomb(GameObject _obj)
    // {
    //     _obj.SetActive(false);
    // }
}
