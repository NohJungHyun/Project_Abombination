using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MindSetting
{
    public string characterActionName;

    [SerializeField]
    public TestAction characterAction;
}

public class EnemyMind : MonoBehaviour
{
    public EnemyActionBox enemyActionBox;
    public Temp_Character controlledCharacter;

    [SerializeField]
    public List<MindSetting> characterTurnActions = new List<MindSetting>();

    public EnemyMind(Temp_Character _Character)
    {
        controlledCharacter = _Character;
    }

}
