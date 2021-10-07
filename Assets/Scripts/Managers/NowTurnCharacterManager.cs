using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowTurnCharacterManager : MonoBehaviour
{
    public static NowTurnCharacterManager instance;
    public static Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.
    public Vector3 baseCharacterPos;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
        // coneRangeMesh.enabled = false;
    }

    public void Update()
    {

    }

    public Transform GetNowCharacterTransform()
    {
        return nowPlayCharacter.transform;
    }

    public Temp_Character GetNowCharacter()
    {
        return nowPlayCharacter;
    }

    public void SetNowCharacter(Temp_Character _now)
    {
        nowPlayCharacter = _now;
    }

    public void ResetCharacterPos()
    {
        if(nowPlayCharacter)
            baseCharacterPos = nowPlayCharacter.transform.position;
        else
            baseCharacterPos = Vector3.zero;
    }
}
