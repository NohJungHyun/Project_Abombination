﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombModifier : BaseUIStorage
{
    public NowTurnCharacterManager nowTurnCharacterManager;
    ModifyAbombination modifyAbombination;

    [Header("Initiating")]
    public Temp_Character nowTurnPlayCharacter;

    public Temp_Character modifiedCharacter;

    public List<Bomb> targetedBombs;
    public Bomb targetedBomb;

    int characterIndex = 0;

    [Header("bombIndex")]
    public Slider bombIndexSlider;
    public int previousIndex;

    [Header("About Bomb")]
    public Button curBombButton;

    public Text countdownText;
    public Button plusCountdown;
    public Button minusCountdown;

    public Button increaseIndexButton;
    public Button decreaseIndexButton;

    public Button boomButton;
    public Button diffuseButton;

    [Header("About Explosion")]
    public ScrollRect explosionScrollRect;

    [Header("About Decision")]
    public Button adjustButton;
    public Button cancleButton;

    [SerializeField] int predictedCost;
    [SerializeField] int predictedCountdown;
    [SerializeField] Button[] explosionButtonList;

    // Start is called before the first frame update
    void Start()
    {
        predictedCost = 0;
        predictedCountdown = 0;

        bombIndexSlider.value = 0;
        previousIndex = 0;

        countdownText.text = " ";

        // ResetExplosionScrollRect();
        // ResetButtons();

        // if(targetedBomb)
        //     SetEventButtons();

        explosionButtonList = explosionScrollRect.content.GetComponentsInChildren<Button>();
        explosionScrollRect.gameObject.SetActive(false);

        for (int i = 0; i < explosionButtonList.Length; i++)
        {
            explosionButtonList[i].gameObject.SetActive(false);
            explosionButtonList[i].onClick.RemoveAllListeners();
        }

        nowTurnCharacterManager = GameObject.FindObjectOfType<NowTurnCharacterManager>();
    }

    void Update()
    {
        ChangeCurTarget();
    }

    public override void InitUI()
    {

    }

    public void ArrangeModifierUI()
    {
        targetedBomb = targetedBombs[Mathf.RoundToInt(bombIndexSlider.value)];

        if (bombIndexSlider.value < modifiedCharacter.GetHaveBombs().Count - 1)
            increaseIndexButton.interactable = true;
        else
            increaseIndexButton.interactable = false;

        if (bombIndexSlider.value > 0)
            decreaseIndexButton.interactable = true;
        else
            decreaseIndexButton.interactable = false;

        ChangeCountdownText();
        ChangeCurBombImage();

        SetEventButtons();
        // ResetExplosionScrollRect();
    }

    void ResetButtons()
    {
        adjustButton.onClick.RemoveAllListeners();
        cancleButton.onClick.RemoveAllListeners();

        plusCountdown.onClick.RemoveAllListeners();
        minusCountdown.onClick.RemoveAllListeners();

        boomButton.onClick.RemoveAllListeners();
        diffuseButton.onClick.RemoveAllListeners();

        increaseIndexButton.onClick.RemoveAllListeners();
        decreaseIndexButton.onClick.RemoveAllListeners();

        curBombButton.onClick.RemoveAllListeners();

        bombIndexSlider.onValueChanged.RemoveAllListeners();

        ResetExplosionScrollRect();

        Debug.Log("이벤트 캔슬 완료");
    }

    void SetEventButtons()
    {
        ResetButtons();

        adjustButton.onClick.AddListener(() => AdjustDecision());
        cancleButton.onClick.AddListener(() => CancleDecision());

        plusCountdown.onClick.AddListener(() => AddCountdown(targetedBomb.addCountdownCost));
        minusCountdown.onClick.AddListener(() => SubtractCountdown(targetedBomb.subtractCountdownCost));

        boomButton.onClick.AddListener(() => DecideBoom(targetedBomb.boomCost));
        diffuseButton.onClick.AddListener(() => DecideDiffuse(targetedBomb.diffuseCost));

        increaseIndexButton.onClick.AddListener(() => BombIndexIncrease());
        decreaseIndexButton.onClick.AddListener(() => BombIndexDecrease());

        curBombButton.onClick.AddListener(() => ShowExplosionRect());

        bombIndexSlider.onValueChanged.AddListener(delegate { ArrangeModifierUI(); });

        Debug.Log("이벤트 설정 완료");
    }

    void ResetExplosionScrollRect()
    {
        int i = 0;

        while (i < explosionButtonList.Length)
        {
            print("i의 값:");
            explosionButtonList[i].onClick.RemoveAllListeners();
            explosionButtonList[i].image.sprite = null;
            explosionButtonList[i].gameObject.SetActive(false);
            i++;
        }

        if (targetedBomb && targetedBomb.explosionList.Count > 0)
            ArrangeExplosionScrollRect();
    }

    void ArrangeExplosionScrollRect()
    {
        for (int idx = 0; idx < targetedBomb.GetExplosionsList().Count; idx++)
        {
            int eventI = idx;
            explosionButtonList[idx].gameObject.SetActive(true);
            explosionButtonList[idx].onClick.AddListener(() => GetOutExplosion(targetedBomb.GetExplosionsList()[eventI]));

            explosionButtonList[idx].image.sprite = targetedBomb.GetExplosionsList()[idx].GetSprite();
        }
    }

    void ChangeCurBombImage()
    {
        if (targetedBomb)
            curBombButton.image.sprite = targetedBomb.GetSprite();
    }

    public void AddCountdown(int _cost)
    {
        if (nowTurnPlayCharacter.GetActionPoint() < targetedBomb.addCountdownCost) return;

        if(predictedCountdown < 0)
        {
            CalculateCost(-_cost);
        }
        else
        {
            CalculateCost(_cost);
        }

        predictedCountdown++;
        ChangeCountdownText();
        print("predictedCost: " + predictedCost);
    }

    public void SubtractCountdown(int _cost)
    {
        if (nowTurnPlayCharacter.GetActionPoint() < targetedBomb.subtractCountdownCost) return;

        if(predictedCountdown > 0)
        {
            CalculateCost(-_cost);
        }
        else
        {
            CalculateCost(_cost);
        }

        predictedCountdown--;
        ChangeCountdownText();
        print("predictedCost: " + predictedCost);
    }

    public void BombIndexIncrease()
    {
        Debug.Log("푸티스");
        if (modifiedCharacter.GetHaveBombs().Count <= 0) return;

        if (bombIndexSlider.value < modifiedCharacter.GetHaveBombs().Count)
        {
            bombIndexSlider.value++;
            // targetedBomb = targetedBombs[Mathf.RoundToInt(bombIndexSlider.value)];

            countdownText.text = targetedBomb.bombCurCountDown.ToString();
        }

        ArrangeModifierUI();
    }

    public void BombIndexDecrease()
    {
        Debug.Log("펜서히어");
        if (modifiedCharacter.GetHaveBombs().Count <= 0) return;

        if (bombIndexSlider.value > 0)
        {
            bombIndexSlider.value--;
            countdownText.text = targetedBomb.bombCurCountDown.ToString();
        }

        ArrangeModifierUI();
    }

    public void DecideBoom(int _cost)
    {
        if (!targetedBomb || nowTurnPlayCharacter.GetActionPoint() < _cost) return;

        BoomBomb boomB = new BoomBomb(BattleController.instance);
        boomB.GetBomb(targetedBomb);
        modifyAbombination.ChangeModifyAction(boomB);
    }

    public void DecideDiffuse(int _cost)
    {
        if (!targetedBomb || nowTurnPlayCharacter.GetActionPoint() < _cost) return;

        DiffuseBomb diffuseB = new DiffuseBomb(BattleController.instance);
        diffuseB.GetBomb(targetedBomb);
        modifyAbombination.ChangeModifyAction(diffuseB);
    }

    public void CalculateCost(int _cost)
    {
        predictedCost += _cost;
    }

    public void AdjustDecision()
    {
        if (nowTurnPlayCharacter.GetActionPoint() > predictedCost)
        {
            nowTurnPlayCharacter.SubtractActionPoint(predictedCost);
            targetedBomb.bombCurCountDown += predictedCountdown;

            if (targetedBomb.bombCurCountDown <= 0)
                targetedBomb.Boom();
        }

        CancleDecision();
    }

    public void CancleDecision()
    {
        predictedCost = 0;
        predictedCountdown = 0;

        ChangeCountdownText();
    }

    public void ChangeCountdownText()
    {
        if (!targetedBomb) return;

        if (predictedCountdown > 0)
        {
            countdownText.color = Color.green;
            countdownText.text = targetedBomb.bombCurCountDown + " + " + predictedCountdown.ToString();
        }
        else if (predictedCountdown < 0)
        {
            countdownText.color = Color.red;
            countdownText.text = targetedBomb.bombCurCountDown + " - " + (-predictedCountdown).ToString();
        }
        else
        {
            countdownText.text = targetedBomb.bombCurCountDown.ToString();
            countdownText.color = Color.gray;
        }
    }

    void ShowExplosionRect()
    {
        if (explosionScrollRect.gameObject.activeInHierarchy)
            explosionScrollRect.gameObject.SetActive(false);
        else
        {
            explosionScrollRect.gameObject.SetActive(true);
            ResetExplosionScrollRect();
            // ManageExplosion();
        }
    }

    public void GetOutExplosion(Explosion _explosion)
    {
        targetedBomb.RemoveExplosionToList(_explosion);
        CharacterActionController.instance.SetState(new RemoveExplosion(BattleController.instance));
    }

    public void SetModifiedCharacter(Temp_Character _target)
    {
        print(_target.name + "!!!");
        bombIndexSlider.value = 0;

        modifiedCharacter = _target;
        targetedBombs = modifiedCharacter.GetHaveBombs();

        if (targetedBombs.Count > 0)
        {
            targetedBomb = targetedBombs[Mathf.RoundToInt(bombIndexSlider.value)];

            bombIndexSlider.maxValue = modifiedCharacter.GetHaveBombs().Count - 1;
            bombIndexSlider.minValue = 0;

            ArrangeModifierUI();
        }
        else
        {
            targetedBomb = null;
            curBombButton.image.sprite = null;
            countdownText.text = " ";

            ResetButtons();
        }
    }

    public void ChangeCurTarget()
    {
        if (nowTurnCharacterManager.GetVisibleTargets().Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (characterIndex > 0)
                {
                    characterIndex--;
                    Debug.Log("characterIndex--: " + characterIndex);

                    SetModifiedCharacter(nowTurnCharacterManager.GetVisibleTargets()[characterIndex].GetComponent<Temp_Character>());
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (characterIndex < nowTurnCharacterManager.GetVisibleTargets().Count - 1)
                {
                    characterIndex++;
                    Debug.Log("characterIndex++: " + characterIndex);

                    SetModifiedCharacter(nowTurnCharacterManager.GetVisibleTargets()[characterIndex].GetComponent<Temp_Character>());
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (nowTurnCharacterManager.GetVisibleTargets().Equals(SearchWithRayCast.GetHitCharacter()))
                {
                    Debug.Log("하히후헤호");
                }
            }
        }
    }

    public void SetAbombinationModifier(ModifyAbombination _m) => modifyAbombination = _m;
    

    public void SetNowTurnPlayCharacter(Temp_Character _Character) => nowTurnPlayCharacter = _Character;
    
}
