using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects / new CharacterActionContainer")]
public class CharacterActionContainer : ScriptableObject
{
    public List<CharacterAction> ca = new List<CharacterAction>();
}
