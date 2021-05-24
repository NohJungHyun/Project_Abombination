using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEventManager : EventBoxesManager
{
    Temp_Character temp_Character;
    // public EventDictionaryInBattle battleStateEventBoxDictionary = new EventDictionaryInBattle();

    public List<DelegateForEventBox> waitOrderList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> moveList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> useItemList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> useSkillList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> createBombList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> diffuseBombList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> boomBombList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> addExplosionList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> removeExplosionList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> modifyAbombinationList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> runBattleList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> SelectTargetList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> turnStartList = new List<DelegateForEventBox>();
    public List<DelegateForEventBox> turnEndList = new List<DelegateForEventBox>();



    public
    // Start is called before the first frame update
    void Start()
    {
        temp_Character = GetComponent<Temp_Character>();
    }
}
