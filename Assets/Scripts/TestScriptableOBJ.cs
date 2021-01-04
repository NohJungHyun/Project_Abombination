using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptableOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterInfo sctObj;


    public void Start()
    {
        CharacterInfo someInstance = ScriptableObject.CreateInstance("Temp") as CharacterInfo;

    }
}
