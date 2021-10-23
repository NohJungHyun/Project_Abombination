using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAreaController : CharacterComponents
{
    ConeRangeMesh rangeMesh;

    bool isOver;

    float maxValue;
    float minValue;
    public float curValue;

    float exhaustRate;

    float timeChecker;

    public float ExhauseRate
    {
        get { return exhaustRate; }
        set { exhaustRate = value; }
    }

    public CharacterMoveAreaController(CharacterInfo info, Temp_Character _owner, ConeRangeMesh _rangeMesh) : base(info, _owner)
    {
        this.info = info;
        owner = _owner;
        rangeMesh = _rangeMesh;
        rangeMesh.enabled = false;

        isOver = false;

        Debug.Log("생성자");
    }

    public override void Init()
    {
        maxValue = info.maxMoveAreaRadius;
        minValue = info.minMoveAreaRadius;
        Reset();

        Debug.Log("Init 진행");
    }

    public void Reset()
    {
        curValue = maxValue;

        if (exhaustRate > 0)
            curValue *= exhaustRate;

        isOver = false;
    }

    public List<Transform> GetVisibleTargets()
    {
        return rangeMesh.GetVisibleTargets();
    }

    public void TurnOnMoveAreaMesh(bool isOn)
    {
        rangeMesh.SetRadius(curValue);
        rangeMesh.enabled = isOn;

        if (isOn)
        {
            rangeMesh.CreateMesh();
            rangeMesh.SetRadius(curValue);
        }
        else
            rangeMesh.DestroyMesh();
    }

    public bool ShrinkArea(float shrinkRate)
    {
        if (rangeMesh.enabled != true) return false;

        if (curValue > minValue)
        {
            curValue -= shrinkRate;
            rangeMesh.SetRadius(curValue);
        }
        else
        {
            HoldRangeMeshPos(owner.transform.position);

            if (Vector3.Distance(rangeMesh.gameObject.transform.position, owner.transform.position) > minValue)
                CallSubtractCountDown();
            return true;
        }

        return false;
    }

    public void HoldRangeMeshPos(Vector3 pos)
    {
        if (isOver == false)
        {
            rangeMesh.transform.SetParent(NowTurnCharacterManager.instance.transform);
            rangeMesh.transform.position = pos;
            isOver = true;
        }
    }

    public void BackToCharacter()
    {
        // Debug.Log(rangeMesh.transform.parent);
        rangeMesh.transform.SetParent(owner.transform.Find("Rotation").transform);
        rangeMesh.transform.position = owner.transform.position + Vector3.up * 0.01f;
        rangeMesh.SetRadius(0);
        isOver = false;
    }

    public void CallSubtractCountDown()
    {
        if (owner.CarriedBombContainer.haveBombs.Count <= 0) return;

        BombData firstBomb = owner.CarriedBombContainer.GetHaveBombs()[0];

        timeChecker += Time.deltaTime * 0.5f;

        Debug.LogWarning("폭탄 체크:" + firstBomb.GetName() + ", " + firstBomb.CurCountDown);

        firstBomb.AdjustCurCountDown(-(int)timeChecker);

        if (firstBomb.CurCountDown <= 0)
        {
            timeChecker = 0;
        }

    }

    public ConeRangeMesh GetRangeMesh()
    {
        return rangeMesh;
    }
}
