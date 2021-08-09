using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedPlayerThings : ThingsInGame
{
    protected Player player;

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayer(Player _owner)
    {
        player = _owner;
    }
}
