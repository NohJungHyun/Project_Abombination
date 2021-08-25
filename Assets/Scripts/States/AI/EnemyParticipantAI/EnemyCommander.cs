using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommander : Participants
{
    public override void Init()
    {
        EngageSelectedCharacter();
    }

    public void EngageSelectedCharacter()
    {
        NowTurnCharacterManager.instance.SetNowCharacter(SelectPlayCharacter());

        BattleController.instance.SetState(new PlayerTurnStartState(BattleController.instance));
    }

    public Temp_Character SelectPlayCharacter()
    {
        int ranSelect = Random.Range(0, haveCharacters.Count);

        return haveCharacters[ranSelect];
    }
}
