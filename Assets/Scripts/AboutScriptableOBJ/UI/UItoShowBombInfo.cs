using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UItoShowBombInfo : MonoBehaviour
{
    public CharacterBattleAction characterBattleAction;

    [Header("현재 전장에 있는 폭탄에 대한 정보를 보여줄 때 띄울 UI")]
    public GameObject showBombContidition;
    public Text bombName;
    public Text bombCount;
    public Image bombImage;
    public Button bombDiffuseButton;
    public Button[] explosionsinBomb = new Button[10];

    public bool isUIOn = false;
    public int indexBomb = 0;
    
    // raycast로 부터 정보를 받기
    public void GetInfofromRaycast(RaycastHit _h)
    {
        if (_h.collider.GetComponent<Temp_Character>())
        {
            if (!isUIOn)
            {
                Temp_Character t = _h.collider.GetComponent<Temp_Character>();

                showBombContidition.SetActive(true);
                ClearEvents();
                ExhibitBombCondition(t.haveBombs);
                ExhibitExplosionsCondition(t);
            }
            else
                showBombContidition.SetActive(false);
        }
    }

    // 현재 선택한 폭탄의 상태를 확인하기 위해 만든 함수.
    public void ExhibitBombCondition(List<Bomb> _bombs)
    {
        // DiffuseBomb(_b);
        if (_bombs.Count> 0 && _bombs[0])
        {
            bombName.text = _bombs[0].bombName;
            bombCount.text = _bombs[0].bombCountDown.ToString();
            bombImage.sprite = _bombs[0].bombImage;

            bombDiffuseButton.onClick.AddListener(() => characterBattleAction.DiffuseBomb(_bombs, _bombs[0]));
        }
    }

    public void ExhibitDiffuse(Temp_Character _t)
    {

    }

    public void ExhibitExplosionsCondition(Temp_Character _t)
    {
        for (int b = 0; b < _t.haveBombs.Count; b++) // 이거는 폭탄의 개수 파악
        {
            for (int e = 0; e < _t.haveBombs[b].explosionList.Count; e++) // 이거는 폭탄 내 폭발물 개수 파악
            {
                int bombCheckIndex = b;
                int explosionCheck = e;

                explosionsinBomb[explosionCheck].image.sprite = _t.haveBombs[bombCheckIndex].explosionList[explosionCheck].exploImage;
                explosionsinBomb[explosionCheck].GetComponentInChildren<Text>().text = _t.haveBombs[bombCheckIndex].explosionList[explosionCheck].exploCountDown.ToString();

                Debug.Log(bombCheckIndex);

                if (characterBattleAction)
                    explosionsinBomb[explosionCheck].onClick.AddListener(() => characterBattleAction.DoExplosionDiffuse(_t.haveBombs[bombCheckIndex].explosionList[explosionCheck]));
            }
        }

    }

    public void ClearEvents()
    {
        bombDiffuseButton.onClick.RemoveAllListeners();

        if (explosionsinBomb.Length <= 0) return;

        for (int e = 0; e < explosionsinBomb.Length; e++)
        {
            explosionsinBomb[e].onClick.RemoveAllListeners();
        }


    }

    // 획일화된 코드 관리를 위해 characterBattleAction에서 diffuseBomb을 관리.
    // public void DiffuseBomb(GameObject _obj)
    // {
    //     _obj.SetActive(false);
    // }
}
