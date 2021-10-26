using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Skill/SetTarget/Heal")]
public class HealSkill : ActiveSkill, ISelectable
{
    public int healNum; // 전체적인 힐량

    // 선택 대상 수
    public int selectTargetNum;

    // 대상 지정 범위
    public float selectRange;

    bool isSelectEnd;

    public List<Temp_Character> selectedCharacter;

    public void OnEnable()
    {
        // Activation += Use;

        selectedCharacter.Clear();
    }

    public new IEnumerator Use()
    {
        for (int c = 0; c < selectedCharacter.Count; c++)
        {
            Debug.Log("힐링 스킬 사용");
            selectedCharacter[c].TakeHeal(healNum);

            Debug.Log(selectedCharacter[c].name + " : " + selectedCharacter[c].curHP);
        }
        yield return null;
        CancleSkill();
    }

    public IEnumerator SelectTarget()
    {
        Debug.Log("힐링 스킬 대상 지정");

        isSelectEnd = false;

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSelectEnd = true;
                yield return Use();
                yield return null;

                ClearSelectedList();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                isSelectEnd = true;
                yield return null;
                ClearSelectedList();
            }

            yield return new WaitUntil(() => isSelectEnd == false);
            
            CheckCharacterWithClick(SearchWithRayCast.GetHitCharacter());

            yield return null;
            // if (selectTargetNum > selectedCharacter.Count)
            // {
            //     if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
            //     {
            //         yield return null;
            //         CheckCharacterWithClick(SearchWithRayCast.GetHitCharacter());
            //     }
            // }
        }
    }

    public void CheckCharacterWithClick(Temp_Character _Character)
    {
        Temp_Character t = _Character;
        if (selectTargetNum > selectedCharacter.Count)
        {
            if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
            {
                Debug.Log("poi");
                if (selectedCharacter.Contains(t))
                {
                    Debug.Log("soi");
                    selectedCharacter.Remove(t);
                }
                else
                {
                    Debug.Log("boi");
                    selectedCharacter.Add(t);
                }
            }
        }
    }


    // public bool CheckCharacterWithClick(Temp_Character _Character)
    // {
    //     if (Input.GetMouseButtonDown(0) && SearchWithRayCast.GetHitCharacter())
    //     {
    //         Temp_Character t = SearchWithRayCast.GetHitCharacter();
    //         Debug.Log("poi");
    //         if (t)
    //         {
    //             Debug.Log("soi");
    //             selectedCharacter.Remove(t);
    //         }
    //         else
    //         {
    //             Debug.Log("boi");
    //             selectedCharacter.Add(t);
    //         }
    //         return true;
    //         // // Temp_Character t = SearchWithRayCast.GetHitCharacter();

    //         // if (SearchWithRayCast.GetHitCharacter())
    //         // {

    //         // }
    //         // else
    //         // {
    //         //     return false;
    //         // }
    //     }
    //     else
    //         return false;
    // }

    public void CastSkill()
    {

    }

    public void CancleSkill()
    {
        Debug.Log("스킬 취소");
    }

    public void ClearSelectedList()
    {
        selectedCharacter.Clear();
        Debug.Log("선택은 여기까지!");
    }
}
