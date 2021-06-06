using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterUI : MonoBehaviour
{
    public Player player;
    public List<Image> commandPointOutlines;

    [SerializeField] int pointIdx = 0;

    public bool canProceed;

    void Start()
    {
        ResetCommandPoints();

        for (int p = 0; p < player.maxCommandPoint; p++)
        {
            /// Debug.Log("???");
            commandPointOutlines[p].gameObject.SetActive(true);
            commandPointOutlines[p] = commandPointOutlines[p].GetComponentInChildren<Image>();
        }
    }

    public bool SpendCommandPoints(int _cpCost)
    {
        StartCoroutine(FadeOutPoint(_cpCost));
        return canProceed;
    }

    public void ResetCommandPoints()
    {
        for (int i = 0; i < commandPointOutlines.Count; i++)
        {
            commandPointOutlines[i].gameObject.SetActive(false);
        }
    }

    public void TurnOffThis()
    {
        gameObject.SetActive(false);
        // CancelInvoke("TurnOffThis");
    }

    public IEnumerator FadeOutPoint(int _cpCost)
    {
        int i = 0;
        while (i < _cpCost)
        {
            yield return new WaitForSeconds(0.2f);

            Debug.Log("wwww");
            commandPointOutlines[i].gameObject.SetActive(false);
            i++;
        }
        yield return new WaitForSeconds(0.2f);
        canProceed = true;
        TurnOffThis();
    }

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
