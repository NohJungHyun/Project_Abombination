using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public Image characterImage; //캐릭터의 스프라이트 정보를 가져와 출력하는 스프라이트
    public Image hpBar; //캐릭터의 체력 바를 출력
    public Image[] actionPointBar; //캐릭터가 지닌 액션 포인트를 의미. 

    public GameObject characterActCanvas;

    public GameObject CreateBombCanvas;

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

    public void GetCreateBombPanel()
    {
        characterActCanvas.SetActive(false);
        CreateBombCanvas.SetActive(true);
    }

    public void SetBombListinUI()
    {
        
    }
}
