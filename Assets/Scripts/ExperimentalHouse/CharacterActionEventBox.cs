using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterActionEventBox : EventBox
{
    public static BattleEventManager instance;
    // public static List<EventBox> EventBoxes;

    public EventDictionaryInBattle characterActionBoxDictionary = new EventDictionaryInBattle();
}
