using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedPlayerThings : ThingsInGame
{
    protected Participants participants;

    public Participants GetParticipants()
    {
        return participants;
    }

    public void SetParticipants(Participants _owner)
    {
        participants = _owner;
    }
}
