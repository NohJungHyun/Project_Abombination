using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleParticipantsManager : MonoBehaviour
{
    int idx = 0;

    public static BattleParticipantsManager instance;

    public static Participants nowTurnParticipant;

    public List<Participants> battleParticipants = new List<Participants>(10);

    public List<Temp_Character> characterList = new List<Temp_Character>(); // 전투에 참여하는 캐릭터들을 담는 리스트.

    void Awake()
    {        
        if (instance != null)
            Destroy(instance);

        instance = this;

        nowTurnParticipant = battleParticipants[0];
    }

    private void Start()
    {
        for (int i = 0; i < battleParticipants.Count; i++)
            characterList.AddRange(battleParticipants[i].haveCharacters);
    }

    public void SetNowTurnParticipants(Participants _p)
    {
        nowTurnParticipant = _p;
    }

    public Participants GetNowTurnParticipant()
    {
        return nowTurnParticipant;
    }

    public void CallNextParticipant()
    {
        if (idx < battleParticipants.Count - 1)
            idx++;
        else
            idx = 0;
        
        nowTurnParticipant = battleParticipants[idx];
        print(nowTurnParticipant.name);
    }
}
