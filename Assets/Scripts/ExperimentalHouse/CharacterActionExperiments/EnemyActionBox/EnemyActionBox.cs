using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionBox : ScriptableObject
{
    List<ICharacterAction> enemyActions = new List<ICharacterAction>();
}
