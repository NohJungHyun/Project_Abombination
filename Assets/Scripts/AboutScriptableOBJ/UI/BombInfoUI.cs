using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombInfoUI : BaseUIStorage
{
    [Header("현재 전장에 있는 폭탄에 대한 정보를 보여줄 때 띄울 UI")]
    public GameObject showBombContidion;
    public Text bombName;
    public Text bombCount;
    public Sprite bombImage;
    public Button bombDiffuseButton;
    public Button[] explosionBomb = new Button[10];

    private Bomb bomb;

    public void GetInfofromBomb(Bomb _bomb)
    {
        bomb = _bomb;

        
    }

    public override void ShowUI()
    {
        bombName.text = bomb.bombName;
        bombCount.text = bomb.bombCountDown.ToString();
        bombImage = bomb.bombImage;
        

        // 후에 이 밑에다가 폭탄 해제 이벤트를 넣도록 하자.

        // throw new System.NotImplementedException();
    }


}
