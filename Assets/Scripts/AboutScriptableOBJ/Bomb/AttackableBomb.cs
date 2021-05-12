using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb", menuName = "ScriptableObjects/BombMaking/AttackableBomb", order = 2)]
public class AttackableBomb : Bomb
{
    public int damage;

    public void SetEventToCharacterActions()
    {

    }

    public void ShowString()
    {
        Debug.Log("attackableBomb이라고 해요!");
    }
}
