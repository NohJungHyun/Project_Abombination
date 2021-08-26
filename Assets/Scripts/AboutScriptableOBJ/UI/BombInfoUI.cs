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

    public void SetInfofromBomb(Bomb _bomb) => bomb = _bomb;
    

    public override void InitUI()
    {

    }
}
