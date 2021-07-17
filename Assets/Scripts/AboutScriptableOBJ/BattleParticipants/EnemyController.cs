using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Participants
{
    public static EnemyController instance;

    public List<Temp_Character> mainCharacters = new List<Temp_Character>();
    public Queue<Temp_Character> usedCharactersQueue = new Queue<Temp_Character>();

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    public void TakePlayCharacter()
    {
        if (!nowTurnCharacterManager.GetNowCharacter())
        {
            for (int i = 0; i < mainCharacters.Count; i++)
            {
                if (curCommandPoint >= mainCharacters[i].GetCharacterInfo().needCommandPoint)
                {
                    PlaySelectedCharacter(mainCharacters[i]);
                    Debug.Log(mainCharacters[i] + ", 이 캐릭터를 이번에 플레이한다");
                    EnqueueUsedCharacter(mainCharacters[i]);
                    break;
                }
            }
        }

        if (!nowTurnCharacterManager.GetNowCharacter())
        {
            for (int j = 0; j < haveCharacters.Count; j++)
            {
                if (curCommandPoint >= haveCharacters[j].GetCharacterInfo().needCommandPoint)
                {
                    PlaySelectedCharacter(haveCharacters[j]);
                    Debug.Log(haveCharacters[j] + ", 이 캐릭터를 이번에 플레이한다");
                    EnqueueUsedCharacter(haveCharacters[j]);
                    break;
                }
            }
        }
    }

    public void PlaySelectedCharacter(Temp_Character _Character)
    {

    }

    void ClearQueue()
    {
        usedCharactersQueue.Clear();
    }

    public void EnqueueUsedCharacter(Temp_Character _Character)
    {
        usedCharactersQueue.Enqueue(_Character);
    }
    public void DequeueUsedCharacter(Temp_Character _Character)
    {
        usedCharactersQueue.Dequeue();
    }
}
