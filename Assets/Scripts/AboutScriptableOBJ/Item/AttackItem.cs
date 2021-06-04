using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackItem : ActiveItem, ISelectable
{
    int selectTargetNum;
    float usableRange;
    float usableAngle;

    bool canPassToUse;

    List<Temp_Character> targets = new List<Temp_Character>();

    public void Attack()
    {

    }

    public IEnumerator SelectTarget()
    {
        while (true)
        {
            if (selectTargetNum > targets.Count) // 아직 더 선택할 수 있음.
            {

            }

            yield return null;
        }
    }

    public override IEnumerator Use()
    {
        yield return new WaitUntil(() => canPassToUse == true);

        for (int t = 0; t < targets.Count; t++)
        {

        }

        yield return null;
    }

    public void CheckCharacterWithClick(Temp_Character _Character)
    {
        Temp_Character t = _Character;
        if (selectTargetNum > targets.Count)
        {
            if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
            {
                Debug.Log("poi");
                if (targets.Contains(t))
                {
                    Debug.Log("soi");
                    targets.Remove(t);
                }
                else
                {
                    Debug.Log("boi");
                    targets.Add(t);
                }
            }
        }
    }
}
