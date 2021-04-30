using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombModifier : MonoBehaviour
{
    [Header("Initiating")]
    public Temp_Character nowTurnPlayCharacter;

    public Temp_Character modifiedCharacter;

    public List<Bomb> targetedBombs;
    public Bomb targetedBomb;

    [Header("bombIndex")]
    public Slider bombIndexSlider;
    public int bombIndex;

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

    public int predictedCost;
    public int predictedCountdown;
    Button[] explosionButtonList;

    // Start is called before the first frame update
    void Start()
    {
        predictedCost = 0;
        predictedCountdown = 0;

        bombIndex = 0;
        countdownText.text = " ";

        ResetExplosionScrollRect();
        ResetButtons();

        if(targetedBomb)
            SetEventButtons();

        explosionButtonList = explosionScrollRect.content.GetComponentsInChildren<Button>();

        for (int i = 0; i < explosionButtonList.Length; i++)
        {
            explosionButtonList[i].gameObject.SetActive(false);
            explosionButtonList[i].onClick.RemoveAllListeners();
        }
    }

    void Update()
    {
        if (modifiedCharacter && modifiedCharacter.GetHaveBombs().Count > 0)
        {
            bombIndex = (int)bombIndexSlider.value;
            targetedBomb = targetedBombs[bombIndex];

            if(bombIndex < modifiedCharacter.GetHaveBombs().Count - 1)
                increaseIndexButton.interactable = true;
            else    
                increaseIndexButton.interactable = false;

            if(bombIndex > 0)
                decreaseIndexButton.interactable = true;
            else    
                decreaseIndexButton.interactable = false;

            ChangeCountdownText();
            ChangeCurBombImage();
        }
    }

    public void EscapeModify()
    {
        gameObject.SetActive(false);
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

        Debug.Log("이벤트 캔슬 완료");
    }

    void SetEventButtons()
    {
        adjustButton.onClick.AddListener(() => AdjustDecision());
        cancleButton.onClick.AddListener(() => CancleDecision());

        plusCountdown.onClick.AddListener(() => AddCountdown(targetedBomb.addCountdownCost));
        minusCountdown.onClick.AddListener(() => SubtractCountdown(targetedBomb.subtractCountdownCost));

        boomButton.onClick.AddListener(() => DecideBoom(targetedBomb.boomCost));
        diffuseButton.onClick.AddListener(() => DecideDiffuse(targetedBomb.diffuseCost));

        increaseIndexButton.onClick.AddListener(() => BombIndexIncrease());
        decreaseIndexButton.onClick.AddListener(() => BombIndexDecrease());

        curBombButton.onClick.AddListener(() => ShowExplosionRect());

        Debug.Log("이벤트 설정 완료");
    }

    void ResetExplosionScrollRect()
    {
        explosionButtonList = explosionScrollRect.content.GetComponentsInChildren<Button>();

        for (int i = 0; i < explosionButtonList.Length; i++)
        {
            explosionButtonList[i].gameObject.SetActive(false);
            explosionButtonList[i].onClick.RemoveAllListeners();
        }

        explosionScrollRect.gameObject.SetActive(false);
    }

    void ChangeCurBombImage()
    {
        curBombButton.image.sprite = targetedBomb.bombImage;
    }

    public void AddCountdown(int _cost)
    {
        if (nowTurnPlayCharacter.GetActionPoint() < predictedCost) return;

        BattleController.instance.SetCharacterAction(new ModifyCountDown(BattleController.instance));

        predictedCountdown++;
        CalculateCost(_cost);
        ChangeCountdownText();
    }

    public void SubtractCountdown(int _cost)
    {
        if (nowTurnPlayCharacter.GetActionPoint() < predictedCost) return;

        predictedCountdown--;
        CalculateCost(_cost);
        ChangeCountdownText();
        BattleController.instance.SetCharacterAction(new ModifyCountDown(BattleController.instance));
    }

    public void BombIndexIncrease()
    {
        Debug.Log("푸티스");
        if(modifiedCharacter.GetHaveBombs().Count <= 0) return;

        if (bombIndex < modifiedCharacter.GetHaveBombs().Count)
        {
            bombIndexSlider.value++;
            countdownText.text = targetedBomb.bombCurCountDown.ToString();
        }

        ResetButtons();
        SetEventButtons();
    }

    public void BombIndexDecrease()
    {
        Debug.Log("펜서히어");
        if(modifiedCharacter.GetHaveBombs().Count <= 0) return;

        if (bombIndex > 0)
        {
            bombIndexSlider.value--;
            ChangeCurBombImage();
            countdownText.text = targetedBomb.bombCurCountDown.ToString();
        }

        ResetButtons();
        SetEventButtons();
    }

    public void DecideBoom(int _cost)
    {
        if(!targetedBomb || nowTurnPlayCharacter.GetActionPoint() > _cost) return;

        BoomBomb boomB = new BoomBomb(BattleController.instance);
        boomB.GetBomb(targetedBomb);
        BattleController.instance.SetCharacterAction(boomB);
    }

    public void DecideDiffuse(int _cost)
    {
        if(!targetedBomb || nowTurnPlayCharacter.GetActionPoint() > _cost) return;

        DiffuseBomb boomB = new DiffuseBomb(BattleController.instance);
        boomB.GetBomb(targetedBomb);
        BattleController.instance.SetCharacterAction(new DiffuseBomb(BattleController.instance));
    }

    public void CalculateCost(int _cost)
    {
        if (predictedCost > 0 && predictedCountdown > 0)
            predictedCost += _cost;
        else
            predictedCost -= _cost;
    }

    public void AdjustDecision()
    {
        if (nowTurnPlayCharacter.GetActionPoint() > predictedCost)
        {
            nowTurnPlayCharacter.SubtractActionPoint(predictedCost);

            if (targetedBomb.bombCurCountDown <= 0)
                targetedBomb.Boom();
            
        }
        else
            Debug.Log("응 무리야");

        gameObject.SetActive(false);
    }

    public void CancleDecision()
    {
        predictedCost = 0;
        predictedCountdown = 0;
    }

    public void ChangeCountdownText()
    {
        if (predictedCountdown > 0)
        {
            // countdownText.text = targetedBomb.bombCurCountDown.ToString() + " + " + predictedCountdown.ToString();
            countdownText.text = (targetedBomb.bombCurCountDown + predictedCountdown).ToString();
            countdownText.color = Color.green;
        }
        else if (predictedCountdown < 0)
        {
            // countdownText.text = targetedBomb.bombCurCountDown.ToString() + "  " + predictedCountdown.ToString();
            countdownText.text = (targetedBomb.bombCurCountDown - predictedCountdown).ToString();
            countdownText.color = Color.red;
            
        }else
        {
            countdownText.text = (targetedBomb.bombCurCountDown).ToString();
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
            ManageExplosion();
        }
            
    }

    void ManageExplosion()
    {
        // explosionButtonList = explosionScrollRect.content.GetComponentsInChildren<Button>();

        for (int i = 0; i < targetedBomb.explosionList.Count; i++)
        {
            explosionButtonList[i].gameObject.SetActive(true);
            explosionButtonList[i].onClick.AddListener(() => GetOutExplosion(targetedBomb.GetExplosionsList()[i]));
        }
    }
    public void GetOutExplosion(Explosion _explosion)
    {
        targetedBomb.RemoveExplosionToList(_explosion);
        BattleController.instance.SetCharacterAction(new RemoveExplosion(BattleController.instance));
    }

    public void SetModifiedCharacter(Temp_Character _target)
    {
        ResetButtons();
        ResetExplosionScrollRect();

        modifiedCharacter = _target;
        targetedBombs = modifiedCharacter.GetHaveBombs();

        if (modifiedCharacter.GetHaveBombs().Count > 0)
        {
            targetedBomb = targetedBombs[bombIndex];
            Debug.Log("targetedBomb: " + targetedBomb);

            bombIndexSlider.maxValue = modifiedCharacter.GetHaveBombs().Count - 1;
            bombIndexSlider.minValue = 0;

            ChangeCurBombImage();
            ChangeCountdownText();
            SetEventButtons();
        }
    }

    public void SetNowTurnPlayCharacter(Temp_Character _Character)
    {
        nowTurnPlayCharacter = BattleController.instance.GetNowPlayCharacter();
    }
}
