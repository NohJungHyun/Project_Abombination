using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterUI : MonoBehaviour
{
    public Player player;
    public List<Image> commandPointOutlines;

    void Start()
    {
        ResetCommandPoints();
        
        for(int p = 0; p <player.maxCommandPoint; p++)
        {
            /// Debug.Log("???");
            commandPointOutlines[p].gameObject.SetActive(true);
            commandPointOutlines.Add(commandPointOutlines[p].GetComponentInChildren<Image>());
        }
    }

    public void CountCommandPoints(int _cpCost)
    {
        // for (int cp = 0; cp < _cpCost; cp++)
        // {
        //     Debug.Log("???");
        //     commandPointOutlines[cp].gameObject.SetActive(false);
        // }
        int cp = 0;
        int index = 0;
        while(cp < _cpCost)
        {
            if(commandPointOutlines[index].gameObject.activeInHierarchy)
            {
                commandPointOutlines[index].gameObject.SetActive(false);
                cp++;
            }
            index++;
        }
        // Debug.Log("Not Enough Command Point!");
    }

    public void ResetCommandPoints()
    {
        for (int i = 0; i < commandPointOutlines.Count; i++)
        {
            commandPointOutlines[i].gameObject.SetActive(false);
        }
    }

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
