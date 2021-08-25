using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowTurnCharacterManager : MonoBehaviour
{
    public static NowTurnCharacterManager instance;
    public static Temp_Character nowPlayCharacter; // 현재 턴에 행동가능한 캐릭터를 의미.
    public Vector3 baseCharacterPos;

    public ConeRangeMesh coneRangeMesh;

    void Awake()
    {
        if (instance != null)
            Destroy(instance);

        instance = this;
    }

    void Start()
    {
        SearchWithRayCast.characterClick += SetNowCharacter;
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
        baseCharacterPos = nowPlayCharacter.transform.position;
    }

    public List<Transform> GetVisibleTargets()
    {
        return coneRangeMesh.GetVisibleTargets();
    }
}
