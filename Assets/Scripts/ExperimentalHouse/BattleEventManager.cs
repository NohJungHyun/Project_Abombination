using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : EventBoxesManager
{
    BattleController battleController;
    // public EventDictionaryInBattle battleStateEventBoxDictionary = new EventDictionaryInBattle();

    public List<DelegateForEventBox> battleStartList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> battleEndList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> battleWinList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> battleLoseList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> roundStartList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> roundEndList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> playerTurnStartList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> playerTurnDoList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> playerTurnEndList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> selectActCharacterList = new List<DelegateForEventBox>();

    void Start()
    {
        battleController = BattleController.instance;
    }
}
