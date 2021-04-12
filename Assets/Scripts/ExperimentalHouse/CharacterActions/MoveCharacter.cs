using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "ScriptableObjects/CharacterActions/MoveCharacter")]
public class MoveCharacter : CharacterAction
{
    public Vector3 from, to;
    bool moving;

    Temp_Character movingCharacter;

    public MoveCharacter(BattleController _battleController) : base(_battleController)
    {
        battleController = _battleController;
        movingCharacter = _battleController.nowPlayCharacter;
        // Setting ㄱㄱ
        from = movingCharacter.GetCharacterPos();

        ControllUI(_battleController.battleUIManager);
        MoveReady();
    }

    public override void EnterCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public override void ControllUI(BattleUIManager _BattleUI)
    {
        _BattleUI.bombUI.SetActive(false);
    }

    public override void ActCharacterAction()
    {
        LookMousePos();
        Moving();
    }

    public override void ExitCharacterAction()
    {
        throw new System.NotImplementedException();
    }

    public void MoveReady()
    {
        Debug.Log("Move Ready");
        float indicatorScale = BattleController.GetNowPlayCharacter().info.characterMovement * 1.5f;

        BattleController.cameraController.doZoom = false;
        SearchWithRayCast.ReturnBasicLayer();
        from = movingCharacter.GetCharacterPos();
        to = Vector3.zero;

        battleController.areaIndicatorStorage.GetCircleIndicator().SetActive(true);

        if (battleController.areaIndicatorStorage && battleController.areaIndicatorStorage.GetCircleIndicator().GetComponent<SpriteRenderer>().transform.localScale == Vector3.one)
        {
            battleController.areaIndicatorStorage.ModifyIndicatorSize(battleController.areaIndicatorStorage.circleIndicator, indicatorScale);
        }

        battleController.areaIndicatorStorage.MoveIndicator(battleController.areaIndicatorStorage.circleIndicator, from);
    }

    public void Moving()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moving = true;
            to = new Vector3(SearchWithRayCast.GetHitPoint().x, 0, SearchWithRayCast.GetHitPoint().z); //BattleController.GetNowCharacterPos().y
            //battleController.areaIndicatorStorage.circleIndicator.SetActive(false);
        }

        if (moving)
        {
            if ((to != Vector3.zero && from != Vector3.zero)) // 이동 가능 거리가 남아있다면.
            {
                Vector3 temp_dist = Vector3.ClampMagnitude(to - from, movingCharacter.info.characterMovement) + from;
                // float clampX = Mathf.Clamp(temp_dist.x, from.x - nowTurnCharacter.info.characterMovement,from.x + nowTurnCharacter.info.characterMovement);
                // float clampZ = Mathf.Clamp(temp_dist.z, from.z - nowTurnCharacter.info.characterMovement,from.z + nowTurnCharacter.info.characterMovement);

                // Debug.Log("temp_dist.x: " + temp_dist.x);
                // Debug.Log("temp_dist.z: " + temp_dist.z);

                movingCharacter.SetCharacterPos(Vector3.MoveTowards(movingCharacter.GetCharacterPos(), temp_dist, 2f * Time.deltaTime)); //temp_dist
            }
        }
    }

    public void LookMousePos()
    {
        Vector3 lookPos = new Vector3(SearchWithRayCast.GetHitPoint().x,movingCharacter.transform.position.y, SearchWithRayCast.GetHitPoint().z); 
        movingCharacter.transform.LookAt(lookPos);
    }
}