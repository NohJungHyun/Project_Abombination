using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAreaController : CharacterComponents
{
    ConeRangeMesh rangeMesh;

    float maxValue;
    float minValue;
    public float curValue;

    public CharacterMoveAreaController(CharacterInfo info, Temp_Character _owner, ConeRangeMesh _rangeMesh) :base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        rangeMesh = _rangeMesh;
        rangeMesh.enabled = false;
        Debug.Log("여기가 왜 안되지");
    }

    public override void Init()
    {
        maxValue = info.maxMoveAreaRadius;
        minValue = info.minMoveAreaRadius;
        curValue = maxValue;

        Debug.Log("이게 먼저인가?");
    }

    public List<Transform> GetVisibleTargets()
    {
        return rangeMesh.GetVisibleTargets();
    }

    public void TurnOnMoveAreaMesh(bool isOn)
    {
        rangeMesh.enabled = isOn;

        if (isOn)
        {
            rangeMesh.CreateMesh();
            rangeMesh.SetRadius(curValue);
        }
        else
            rangeMesh.DestroyMesh();
    }


}
