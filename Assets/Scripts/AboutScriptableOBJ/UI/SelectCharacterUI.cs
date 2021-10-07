using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterUI : BaseUIStorage
{
    public List<Image> commandPointOutlines;

    public bool canProceed;

    public override void InitUI()
    {
        base.InitUI();
    }

    public void Resetting(Participants participants)
    {
        base.InitUI();

        int commandPoint = participants.curCommandPoint;

        for (int p = 0; p < commandPoint; p++)
        {
            commandPointOutlines[p].gameObject.SetActive(true);
            commandPointOutlines[p] = commandPointOutlines[p].GetComponentInChildren<Image>();
        }

        // ResetCommandPoints(commandPoint);
    }

    void SpendCommandPoints(int _cpCost)
    {
        //print(canProceed);
        StartCoroutine(FadeOutPoint(_cpCost));
        //print(canProceed);
        StopCoroutine(FadeOutPoint(_cpCost));
    }

    public IEnumerator FadeOutPoint(int _cpCost)
    {
        int i = 0;
        while (i < _cpCost)
        {
            yield return new WaitForSeconds(0.2f);

            commandPointOutlines[i].gameObject.SetActive(false);
            i++;
        }
        yield return new WaitForSeconds(0.2f);
        canProceed = true;
    }

    // public void CheckPlayCondition(bool _on, Temp_Character selectedCharacter)
    // {
    //     OnTurnEndButton(_on, selectedCharacter);
    //     DecidePlay(selectedCharacter);
    // }

    public void DecidePlay(Temp_Character selectedCharacter)
    {
        if (NowTurnCharacterManager.nowPlayCharacter)
            if (BattleParticipantsManager.nowTurnParticipant.AdjustPoint(false, selectedCharacter.GetCharacterInfo().needCommandPoint))
            {
                battleUIManager.turnEndButton.gameObject.SetActive(false);
                SpendCommandPoints(selectedCharacter.GetCharacterInfo().needCommandPoint);
                canProceed = false;
            }
    }

    public void OnTurnEndButton(bool _on, Temp_Character selectedCharacter)
    {
        battleUIManager.turnEndButton.gameObject.SetActive(_on);
        battleUIManager.turnEndButton.onClick.RemoveAllListeners();

        if (_on)
        {
            if (BattleParticipantsManager.nowTurnParticipant == selectedCharacter.GetParticipants())
            {
                battleUIManager.turnEndButton.GetComponentInChildren<Text>().text = "Play Character";
                battleUIManager.turnEndButton.onClick.AddListener(() => DecidePlay(selectedCharacter));
            }
            else
            {
                battleUIManager.turnEndButton.GetComponentInChildren<Text>().text = "Phase End";
                battleUIManager.turnEndButton.onClick.AddListener(() => BattleController.instance.SetState(new PhaseEnd(BattleController.instance)));
            }

        }
    }

    // private void OnDisable()
    // {
    //     print("disable");
    //     Transform[] childrend = GetComponentsInChildren<Transform>();
    //     foreach (Transform obj in childrend)
    //         if(obj != this.transform)
    //             obj.gameObject.SetActive(false);
    // }

    // private void OnEnable()
    // {
    //     Transform[] childrend = GetComponentsInChildren<Transform>();
    //     foreach (Transform obj in childrend)
    //         if(obj != this.transform)
    //             obj.gameObject.SetActive(true);
    // }

    // public void DisappearImage()
    // {

    //     pointIdx++;
    // }

    // IEnumerator FadeOutUI(int _cpCost)
    // {
    //     yield return FadeOutImage(_cpCost);
    //     yield return new WaitForSeconds(1f);

    //     CheckSpendPoint = false;
    //     gameObject.SetActive(false);
    // }

    // IEnumerator FadeOutImage(int _cpCost)
    // {
    //     int i = 0;
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(1f);

    //         if (DisappearImage(commandPointOutlines[i]))
    //             commandPointOutlines[i].gameObject.SetActive(false);

    //         if (i < _cpCost)
    //             i++;
    //         else
    //             yield break;
    //     }
    // }

    // public void CheckPointImage(bool _isOn, int _index)
    // {
    //     for(int p = 0; p < _index; p++)
    //     {
    //         if(_isOn)
    //             commandPoints[p].gameObject.SetActive(true);
    //         else    
    //             commandPoints[p].gameObject.SetActive(false);
    //     }
    // }

}
