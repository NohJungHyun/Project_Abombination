using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public Temp_Character temp_Character;
    // 폭탄의 상태 관리, 설치 등을 통제하고자 제작.
    public BombManager bombManager;

    // public Image characterImage; //캐릭터의 스프라이트 정보를 가져와 출력하는 스프라이트
    // public Image hpBar; //캐릭터의 체력 바를 출력
    // public Image[] actionPointBar; //캐릭터가 지닌 액션 포인트를 의미. 

    public delegate void UIControllor();
    public UIControllor uIControllor = null;

    public GameObject characterActCanvas;

    public GameObject CreateBombCanvas;

    public List<Button> bombButtons = new List<Button>(20);
    public List<Bomb> bombs = new List<Bomb>();

    // Start is called before the first frame update
    void Start()
    {
        characterActCanvas.SetActive(false);
        CreateBombCanvas.SetActive(false);
    }

    public void ActivateActionUI()
    {
        characterActCanvas.SetActive(true);
        CreateBombCanvas.SetActive(false);
    }

    public void GetBombPanel()
    {
        characterActCanvas.SetActive(false);
        CreateBombCanvas.SetActive(true);
    }

    // 현재 캐릭터가 지닌 폭탄 목록을 UI에 출력 및 버튼 이벤트 추가.
    public void SetBombListinUI(Temp_Character _t)
    {
        if (_t)
        {
            temp_Character = _t;
            Debug.Log(CreateBombCanvas.GetComponentsInChildren<Button>().Length);

            if (temp_Character.canSetBombs.Count > 0)
            {
                if (temp_Character.canSetBombs.Count <= CreateBombCanvas.GetComponentsInChildren<Button>().Length)
                {
                    // for (int u = 0; u < CreateBombCanvas.GetComponentsInChildren<Button>().Length - 1; u++)
                    for (int u = 0; u < temp_Character.canSetBombs.Count; u++)
                    {
                        int uiIndex = u;
                        Debug.Log(uiIndex);
                        bombButtons.Add(CreateBombCanvas.GetComponentsInChildren<Button>()[uiIndex]);
                        // 버튼 이미지
                        bombButtons[uiIndex].image.sprite = _t.canSetBombs[uiIndex].bombImage;
                        // 버튼 클릭 이미지 추가.
                        bombButtons[uiIndex].onClick.AddListener(() => bombManager.CreateBombtoButtonClick(temp_Character.canSetBombs[uiIndex]));
                    }
                }
            }
        }
    }
}
